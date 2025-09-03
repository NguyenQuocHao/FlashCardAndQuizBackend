using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Repositories;

namespace FlashCardAndQuizBackend.Services
{
    public class GeneralService
    {
        private readonly GeneralRepository _generalRepo;
        public GeneralService(GeneralRepository generalRepo)
        {
            _generalRepo = generalRepo;
        }

        public async Task<List<DifficultyLevel>> GetAllDifficulties()
        {
            return await _generalRepo.GetAllDifficulties();
        }

        public async Task<List<FrequencyLevel>> GetAllFrequencies()
        {
            return await _generalRepo.GetAllFrequencies();
        }

        public async Task<List<RegisterLevel>> GetAllRegisters()
        {
            return await _generalRepo.GetAllRegisters();
        }
    }
}