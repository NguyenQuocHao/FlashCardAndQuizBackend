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

        public async Task<List<Meaning>> GetAllMeanings()
        {
            return await _context.Meanings
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

        public async Task DeleteMeaning(Meaning meaning)
        {
            _context.Meanings.Remove(meaning);

            await _context.SaveChangesAsync();
        }
    }
}
