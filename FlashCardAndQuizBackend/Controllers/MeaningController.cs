using FlashCardAndQuizBackend.Enums;
using FlashCardAndQuizBackend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardAndQuizBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeaningController : ControllerBase
    {
        private readonly MeaningService _meaningService;
        public MeaningController(MeaningService meaningService)
        {
            _meaningService = meaningService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMeaning([FromBody] CreateMeaningRequest request)
        {
            await _meaningService.CreateMeaningAsync(request);

            return Ok("Word definition created successfully");
        }

        //public async Task<IActionResult> GetAllMeanings()
        //{
        //    var meanings = await _meaningService.GetAllMeanings();

        //    return Ok(meanings);
        //}


    }

    public record CreateMeaningRequest(int WordId, 
        string Description,
        string Note,
        string WordType,
        string[] Tags,
        Difficulty Difficulty = Difficulty.Moderate,
        Register Register = Register.Consultative,
        Frequency Frequency = Frequency.Occasional,
        Importance Importance = Importance.Medium,
        string Example = ""
    );
}
