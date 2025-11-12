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


        [HttpGet("/api/word/{wordId}/meaning/getAll")]
        public async Task<IActionResult> GetAllMeanings(int wordId)
        {
            var meanings = await _meaningService.GetAllWordMeanings(wordId);

            return Ok(meanings);
        }

        [HttpPut("/api/word/{wordId}/meanings")]
        public async Task<IActionResult> UpdateMeanings(int wordId, [FromBody] UpdateMeaningsRequest request)
        {
            await _meaningService.UpdateMeanings(wordId, request);

            return Ok("Good");
        }
    }
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

public record UpdateMeaningsRequest(MeaningRequest[] Meanings,
    int[] DeletedIds
);

public record MeaningRequest(int Id,
    string Description,
    string Note,
    string WordType,
    string[] Tags,
    ExampleResponse[] Examples,
    Difficulty Difficulty = Difficulty.Moderate,
    Register Register = Register.Consultative,
    Frequency Frequency = Frequency.Occasional,
    Importance Importance = Importance.Medium
);

public record GetMeaningResponse(int Id,
    string Description,
    string Note,
    string WordType,
    GetTagResponse[] Tags,
    ExampleResponse[] Examples,
    Difficulty Difficulty = Difficulty.Moderate,
    Register Register = Register.Consultative,
    Frequency Frequency = Frequency.Occasional,
    Importance Importance = Importance.Medium
);

public record ExampleResponse(int Id, string Content);