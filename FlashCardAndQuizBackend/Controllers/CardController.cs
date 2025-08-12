using Microsoft.AspNetCore.Mvc;
using FlashCardAndQuizBackend.Services;
using FlashCardAndQuizBackend.Models;
using FlashCardAndQuizBackend.Enums;

namespace FlashCardAndQuizBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardService _cardSerivce;
        public CardController(CardService cardService)
        {
            _cardSerivce = cardService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCard([FromBody]CreateFlashCardRequest request)
        {
            await _cardSerivce.CreateCardAsync(request);

            return Ok("Card created successfully");
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await _cardSerivce.GetAllFlashCards();

            return Ok(cards);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCard(int id)
        {
            var card = await _cardSerivce.GetCardById(id);

            return Ok(card);
        }

        [HttpPut("update/{cardId}")]
        public async Task<IActionResult> UpdateLexicalUnit(int cardId, [FromBody]UpdateWordRequest request)
        {
            var result = await _cardSerivce.UpdateLexicalUnit(cardId, request);

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            try
            {
                await _cardSerivce.DeleteCard(id);
                return Ok("Card deleted successfully");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

public record CreateFlashCardRequest(
    string Content);

public record GetFlashCardResponse(
    int CardId,
    string WordContent,
    DateTime CardDate);

public record UpdateWordRequest(
    int WordId, string WordContent);

public record CreateExampleRequest(
    string LexicalUnitId,
    string Text);
public record UpdateLexicalUnitResponse(string Content);
