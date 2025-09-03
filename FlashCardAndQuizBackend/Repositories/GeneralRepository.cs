using FlashCardAndQuizBackend.Data;
using FlashCardAndQuizBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardAndQuizBackend.Repositories
{
    public class GeneralRepository
    {
        private readonly DataContext _context;
        public GeneralRepository(DataContext context) {
            _context = context;
        } 

        public async Task<List<DifficultyLevel>> GetAllDifficulties()
        {
            return await _context.DifficultyLevels
                .ToListAsync();
        }

        public async Task<List<FrequencyLevel>> GetAllFrequencies()
        {
            return await _context.FrequencyLevels
                .ToListAsync();
        }

        public async Task<List<RegisterLevel>> GetAllRegisters()
        {
            return await _context.RegisterLevels
                .ToListAsync();
        }
    }
}
