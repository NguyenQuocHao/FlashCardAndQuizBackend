using FlashCardAndQuizBackend.Data;
using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAndQuizBackend.Repositories
{
    public class CardRepository
    {
        private readonly DataContext _context;
        public CardRepository(DataContext context) {
            _context = context;
        } 

        public async Task AddCard(FlashCard card)
        {
            _context.FlashCards.Add(card);

            await _context.SaveChangesAsync();
        }

        public async Task<List<FlashCard>> GetAllCards()
        {
            return await _context.FlashCards
                .Include(fc => fc.LexicalUnit)
                .ToListAsync();
        }

        public async Task<FlashCard?> GetCardById(int id)
        {
            return await _context.FlashCards
                .Include(fc => fc.LexicalUnit)
                .ThenInclude(lu => lu.Meanings)
                .SingleOrDefaultAsync(fc => fc.Id == id);
        }

        public async Task<FlashCard?> GetCardByWord(string word)
        {
            return await _context.FlashCards
                .Include(fc => fc.LexicalUnit)
                .SingleOrDefaultAsync(fc => fc.LexicalUnit.Text == word);
        }

        public async Task<LexicalUnit?> GetLexicalUnit(string word)
        {
            return await _context.LexicalUnits
                .Include(w => w.FlashCard)
                .Include(w => w.Meanings)
                .   ThenInclude(m => m.Tags)
                .Include(w => w.Meanings)
                    .ThenInclude(m => m.SentenceExamples)
                .SingleOrDefaultAsync(w => w.Text == word);
        }

        public async Task UpdateCard(FlashCard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card), "Card cannot be null.");
            }

            _context.FlashCards.Update(card);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCard(FlashCard card)
        {
            // TODO: Add ability to delete lexical unit
            //_context.LexicalUnits.Remove(card.LexicalUnit);
            //await _context.SaveChangesAsync();

            _context.FlashCards.Remove(card);

            await _context.SaveChangesAsync();
        }
    }
}
