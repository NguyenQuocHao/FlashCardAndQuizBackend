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
                    AssignMeaning(newMeaning, meaning, word);
                    toSaveMeanings.Add(newMeaning);
                    continue;
                }

                // Edit meaning
                var existingMeaning = word.Meanings.FirstOrDefault(m => m.Id == meaning.Id);
                if (existingMeaning == null)
                {
                    continue;
                }

                AssignMeaning(existingMeaning, meaning);

                toSaveMeanings.Add(existingMeaning);
            }

            await _meaningRepository.UpdateMeanings(toSaveMeanings);
        }

        private void AssignMeaning(Meaning meaning, GetMeaningResponse request, LexicalUnit word = null)
        {
            meaning.Description = request.Description;
            if (word != null)
            {
                meaning.LexicalUnit = word;
            }
            meaning.Note = request.Note;
            meaning.Type = (WordType)Enum.Parse(typeof(WordType), request.WordType);
            //meaning.Tags = request.Tags;
            meaning.DifficultyLevel = request.Difficulty;
            meaning.FrequencyLevel = request.Frequency;
            meaning.ImportanceLevel = request.Importance;
            meaning.RegisterLevel = request.Register;
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