using FlashCardAndQuizBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashCardAndQuizBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly TagService _tagService;
        public TagController(TagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagRequest request)
        {
            await _tagService.CreateTag(request);

            return Ok("Tag created successfully");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagService.GetAllTags();

            return Ok(tags);
        }

        [HttpPut("update/{tagId}")]
        public async Task<IActionResult> UpdateTag(int tagId, [FromBody] UpdateTagRequest request)
        {
            await _tagService.UpdateTag(tagId, request);

            return Ok("Tag updated successfully");
        }

        [HttpDelete("delete/{tagId}")]
        public async Task<IActionResult> DeleteTag(int tagId)
        {
            await _tagService.DeleteTag(tagId);

            return Ok("Tag deleted successfully");
        }
    }
}

public record CreateTagRequest(string TagName);

public record GetTagResponse(int Id, string Name);

public record UpdateTagRequest(string TagName);