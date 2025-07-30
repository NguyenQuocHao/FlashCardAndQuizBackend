using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardAndQuizBackend.Services
{
    public class CardService
    {
        private readonly CardRepository _cardRepo;
        private readonly LexicalUnitRepository _lexicalUnitRepo;
        public CardService(CardRepository cardRepo, LexicalUnitRepository lexicalUnitRepo)
        {
            _cardRepo = cardRepo;
            _lexicalUnitRepo = lexicalUnitRepo;
        }

        public async Task CreateCardAsync(CreateFlashCardRequest request)
        {
            var existingUnit = await _lexicalUnitRepo.GetLexicalUnitByContent(request.Content);

            if (existingUnit != null)
            {
                throw new ArgumentException("Word or word phrase already exists");
            }

            LexicalUnit lexicalUnit = new()
            {
                Text = request.Content,
            };
            await _lexicalUnitRepo.AddLexicalUnit(lexicalUnit);

            FlashCard flashCard = new()
            {
                LexicalUnit = lexicalUnit,
                CreationDate = DateTime.Now
            };
            await _cardRepo.AddCard(flashCard);

            // Update lexical unit's foreign key to flashcard
            lexicalUnit.FlashCard = flashCard;
            await _lexicalUnitRepo.UpdateLexicalUnit(lexicalUnit);
        }

        public async Task<List<GetFlashCardResponse>> GetAllFlashCards()
        {
            var cards = await _cardRepo.GetAllCards();

            return cards
                .Select(card => new GetFlashCardResponse(card.Id,
                    card.LexicalUnit.Text,
                    card.CreationDate))
                .ToList();
        }

        public async Task<GetFlashCardResponse?> GetCardById(int id)
        {
            var card = await _cardRepo.GetCardById(id);

            if (card != null)
                return new GetFlashCardResponse(card.Id,
                    card.LexicalUnit.Text,
                    card.CreationDate);

            return null;
        }

        public async Task<FlashCard> UpdateLexicalUnit(int cardId, UpdateWordRequest request)
        {
            return await _lexicalUnitRepo.UpdateLexicalUnit(cardId, request);
        }

        public async Task DeleteCard(int id)
        {
            var card = await _cardRepo.GetCardById(id);
            if (card == null)
            {
                throw new KeyNotFoundException("Card not found");
            }

            await _cardRepo.DeleteCard(card);
        }
    }
}