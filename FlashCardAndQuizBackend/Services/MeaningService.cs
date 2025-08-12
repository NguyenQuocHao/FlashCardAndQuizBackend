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

        //public async Task<List<GetFlashMeaningResponse>> GetAllFlashMeanings()
        //{
        //    var cards = await _cardRepo.GetAllMeanings();

        //    return cards
        //        .Select(card => new GetFlashMeaningResponse(card.Id,
        //            card.LexicalUnit.Text,
        //            card.CreationDate))
        //        .ToList();
        //}

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