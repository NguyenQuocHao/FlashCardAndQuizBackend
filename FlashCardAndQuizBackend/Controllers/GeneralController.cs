using Microsoft.AspNetCore.Mvc;
using FlashCardAndQuizBackend.Services;
using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Controllers
{
    [ApiController]
    [Route("api")]
    public class GeneralController : ControllerBase
    {
        private readonly GeneralService _service;
        public GeneralController(GeneralService service)
        {
            _service = service;
        }

        [HttpGet("difficulty/get")]
        public async Task<IActionResult> GetAllDifficulties()
        {
            return Ok(await _service.GetAllDifficulties());
        }

        [HttpGet("frequency/get")]
        public async Task<IActionResult> GetAllFrequencys()
        {
            return Ok(await _service.GetAllFrequencies());
        }

        [HttpGet("register/get")]
        public async Task<IActionResult> GetAllRegisters()
        {
            return Ok(await _service.GetAllRegisters());
        }
    }
}
