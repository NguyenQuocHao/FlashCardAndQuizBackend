using FlashCardAndQuizBackend.Data;
using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAndQuizBackend.Repositories
{
    public class TagRepository
    {
        private readonly DataContext _context;
        public TagRepository(DataContext context) {
            _context = context;
        } 

        public async Task AddTag(Tag tag)
        {
            _context.Tags.Add(tag);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Tag>> GetAllTags()
        {
            return await _context.Tags
                .ToListAsync();
        }

        public async Task<Tag?> GetTagById(int id)
        {
            return await _context.Tags
                .SingleOrDefaultAsync(fc => fc.Id == id);
        }

        public async Task UpdateTag(Tag tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag), "Tag cannot be null.");
            }

            _context.Tags.Update(tag);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTag(Tag tag)
        {
            _context.Tags.Remove(tag);

            await _context.SaveChangesAsync();
        }
    }
}
