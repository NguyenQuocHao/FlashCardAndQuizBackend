using FlashCardAndQuizBackend.Controllers;
using FlashCardAndQuizBackend.Enums;
using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardAndQuizBackend.Services
{
    public class MeaningService
    {
        private readonly MeaningRepository _meaningRepository;
        private readonly LexicalUnitRepository _lexicalUnitRepo;
        public MeaningService(MeaningRepository meaningRepository, LexicalUnitRepository lexicalUnitRepo)
        {
            _meaningRepository = meaningRepository;
            _lexicalUnitRepo = lexicalUnitRepo;
        }

        public async Task CreateMeaningAsync(CreateMeaningRequest request)
        {
            var lexicalUnit = await _lexicalUnitRepo.GetLexicalUnitById(request.WordId);
            if (lexicalUnit == null)
            {
                throw new ArgumentException($"Word with id {request.WordId} doesn't exist");
            }
            var type = (WordType)Enum.Parse(typeof(WordType), request.WordType);
            var meaning = new Meaning()
            {
                LexicalUnit = lexicalUnit,
                Description = request.Description,
                Note = request.Note,
                Type = type,
                //DifficultyLevel = request.Difficulty,
                //RegisterLevel = request.Register,
                //FrequencyLevel = request.Frequency,
                //ImportanceLevel = request.Importance,
            };

            await _meaningRepository.AddMeaning(meaning);

            if (!string.IsNullOrWhiteSpace(request.Example))
            {
                var example = new SentenceExample
                {
                    Sentence = request.Example,
                    //Meaning = meaning,
                };
                example.AddMeanings(meaning);

                await _meaningRepository.AddExample(example);
            }
        }

        public async Task<List<GetMeaningResponse>> GetAllWordMeanings(int wordId)
        {
            var word = await _lexicalUnitRepo.GetLexicalUnitById(wordId, true);

            return word.Meanings
                .Select(meaning => new GetMeaningResponse(meaning.Id,
                    meaning.Description,
                    meaning.Note,
                    meaning.Type.ToString(),
                    meaning.Tags.Select(t => new GetTagResponse(t.Id, t.Name)).ToArray(),
                    meaning.SentenceExamples.Select(t => new ExampleResponse(t.Id, t.Sentence)).ToArray(),
                    meaning.DifficultyLevel,
                    meaning.RegisterLevel,
                    meaning.FrequencyLevel,
                    meaning.ImportanceLevel))
                .ToList();
        }

        public async Task UpdateMeanings(int wordId, UpdateMeaningsRequest request)
        {
            var word = await _lexicalUnitRepo.GetLexicalUnitById(wordId, true);

            await DeleteMeanings(request.DeletedIds);

            List<Meaning> toSaveMeanings = new();

            foreach (var meaning in request.Meanings)
            {
                // Add meaning
                if (meaning.Id == 0)
                {
                    var newMeaning = new Meaning();
                    newMeaning.LexicalUnit = word;
                    newMeaning.DifficultyLevel = meaning.Difficulty;
                    newMeaning.FrequencyLevel = meaning.Frequency;
                    newMeaning.ImportanceLevel = meaning.Importance;
                    newMeaning.RegisterLevel = meaning.Register;
                    newMeaning.Description = meaning.Description;
                    newMeaning.Note = meaning.Note;
                    newMeaning.Type = (WordType)Enum.Parse(typeof(WordType), meaning.WordType);
                    //newMeaning.Tags = meaning.Tags;
                    //newMeaning.SentenceExamples = new List<SentenceExample>();

                    toSaveMeanings.Add(newMeaning);
                    continue;
                }

                // Edit meaning
                var existingMeaning = word.Meanings.FirstOrDefault(m => m.Id == meaning.Id);
                if (existingMeaning == null)
                {
                    continue;
                }

                existingMeaning.Description = meaning.Description;
                existingMeaning.Note = meaning.Note;
                existingMeaning.Type = (WordType)Enum.Parse(typeof(WordType), meaning.WordType);
                //existingMeaning.Tags = meaning.Tags;
                existingMeaning.DifficultyLevel = meaning.Difficulty;
                existingMeaning.FrequencyLevel = meaning.Frequency;
                existingMeaning.ImportanceLevel = meaning.Importance;
                existingMeaning.RegisterLevel = meaning.Register;

                toSaveMeanings.Add(existingMeaning);
            }

            await _meaningRepository.UpdateMeanings(toSaveMeanings);
        }

        public async Task DeleteMeanings(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                if (id < 1)
                {
                    continue;
                }

                var meaning = await _meaningRepository.GetMeaningById(id);
                if (meaning is null)
                {
                    continue;
                }

                await _meaningRepository.DeleteMeaning(meaning);
            }
        }

        //public async Task<GetFlashMeaningResponse?> GetMeaningById(int id)
        //{
        //    var card = await _cardRepo.GetMeaningById(id);

        //    if (card != null)
        //        return new GetFlashMeaningResponse(card.Id,
        //            card.LexicalUnit.Text,
        //            card.CreationDate);

        //    return null;
        //}

        //public async Task<FlashMeaning> UpdateLexicalUnit(int cardId, UpdateWordRequest request)
        //{
        //    return await _lexicalUnitRepo.UpdateLexicalUnit(cardId, request);
        //}

        //public async Task DeleteMeaning(int id)
        //{
        //    var card = await _cardRepo.GetMeaningById(id);
        //    if (card == null)
        //    {
        //        throw new KeyNotFoundException("Meaning not found");
        //    }

        //    await _cardRepo.DeleteMeaning(card);
        //}
    }
}