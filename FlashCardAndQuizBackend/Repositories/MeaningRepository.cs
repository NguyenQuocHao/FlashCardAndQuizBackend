using FlashCardAndQuizBackend.Data;
using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAndQuizBackend.Repositories
{
    public class MeaningRepository
    {
        private readonly DataContext _context;
        public MeaningRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddMeaning(Meaning meaning)
        {
            _context.Meanings.Add(meaning);

            await _context.SaveChangesAsync();
        }

        public async Task AddExample(SentenceExample example)
        {
            _context.SentenceExamples.Add(example);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Meaning>> GetAllMeaningsByWordId(int wordId)
        {
            return await _context.Meanings
                .Include(m => m.LexicalUnit)
                .Include(m => m.Tags)
                .Where(m => m.LexicalUnitId == wordId)
                .ToListAsync();
        }

        public async Task<Meaning?> GetMeaningById(int id)
        {
            return await _context.Meanings
                .SingleOrDefaultAsync(fc => fc.Id == id);
        }

        public async Task UpdateMeaning(Meaning meaning)
        {
            if (meaning == null)
            {
                throw new ArgumentNullException(nameof(meaning), "Meaning cannot be null.");
            }

            _context.Meanings.Update(meaning);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateMeanings(IEnumerable<Meaning> meanings)
        {
            if (meanings == null)
            {
                throw new ArgumentNullException(nameof(meanings), "Meanings cannot be null.");
            }

            _context.Meanings.UpdateRange(meanings);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMeaning(Meaning meaning)
        {
            _context.Meanings.Remove(meaning);

            await _context.SaveChangesAsync();
        }
    }
}
