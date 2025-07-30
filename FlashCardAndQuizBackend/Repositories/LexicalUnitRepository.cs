using FlashCardAndQuizBackend.Data;
using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAndQuizBackend.Repositories
{
    public class LexicalUnitRepository
    {
        private readonly DataContext _context;
        public LexicalUnitRepository(DataContext context) {
            _context = context;
        }

        public async Task AddLexicalUnit(LexicalUnit lexicalUnit)
        {
            if (lexicalUnit == null)
            {
                throw new ArgumentNullException(nameof(lexicalUnit), "Lexical unit cannot be null.");
            }
            _context.LexicalUnits.Add(lexicalUnit);

            await _context.SaveChangesAsync();
        }

        public async Task<List<LexicalUnit>> GetLexicalUnits()
        {
            return await _context.LexicalUnits
                .Include(lu => lu.FlashCard)
                .ToListAsync();
        }

        public async Task<LexicalUnit?> GetLexicalUnitById(int id)
        {
            return await _context.LexicalUnits
                .Include(lu => lu.FlashCard)
                .FirstOrDefaultAsync(lu => lu.Id == id);
        }

        public async Task<LexicalUnit?> GetLexicalUnitByContent(string content)
        {
            return await _context.LexicalUnits
                .Include(lu => lu.FlashCard)
                .FirstOrDefaultAsync(lu => lu.Text == content);
        }

        public async Task<FlashCard> UpdateLexicalUnit(int cardId, UpdateWordRequest request)
        {
            var flashcard = await _context.FlashCards
                .Where(c => c.Id == cardId)
                .Include(c => c.LexicalUnit)
                .SingleAsync();

            flashcard.LexicalUnit.Text = request.WordContent;

            _context.Update(flashcard);

            await _context.SaveChangesAsync();

            return flashcard;
        }

        public async Task UpdateLexicalUnit(LexicalUnit unit)
        {
            _context.Update(unit);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLexicalUnit(int id)
        {
            var lexicalUnit = await _context.LexicalUnits.FindAsync(id);
            if (lexicalUnit == null)
            {
                throw new KeyNotFoundException($"Lexical unit with ID {id} not found.");
            }

            _context.LexicalUnits.Remove(lexicalUnit);
            await _context.SaveChangesAsync();
        }
    }
}
