using HearthStoneApp.Aplication.Dtos;
using HearthStoneApp.Aplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HearthStoneApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var cards = await _cardService.GetCardsAsync();
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard(long id)
        {
            var card = await _cardService.GetCardAsync(id);
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardDto cardDto)
        {
            if (cardDto == null)
                return BadRequest();

            var createdCard = await _cardService.CreateCardAsync(cardDto);
            return CreatedAtAction(nameof(GetCard), new { id = createdCard.CardId }, createdCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(long id, [FromBody] CardDto cardDto)
        {
            if (id != cardDto.CardId)
                return BadRequest();

            var updatedCard = await _cardService.UpdateCardAsync(cardDto);
            if (updatedCard == null)
                return NotFound();

            return Ok(updatedCard);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(long id)
        {
            var result = await _cardService.DeleteCardAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
