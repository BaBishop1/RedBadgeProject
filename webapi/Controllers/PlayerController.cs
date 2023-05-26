using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models.Players;
using webapi.Services.Player;
using webapi.Services.Token;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly ITokenService _tokenService;

        public PlayerController(IPlayerService playerService, ITokenService tokenService)
        {
            _playerService = playerService;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Authorize(Policy = "CustomAdminEntity")]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool createPlayer = await _playerService.CreatePlayerAsync(model);
            if (createPlayer == true)
            {
                return Ok("Player Creation Sucessful");
            }
            else
            {
                return BadRequest("Player Creation Failed");
            }
        }
        [HttpGet("PlayerList")]
        public async Task<IActionResult> GetPlayerList()
        {
            IEnumerable<PlayerListItem> players = await _playerService.GetPlayerListAsync();
            return Ok(players);
        }
        [HttpGet("{playerId:int}")]
        public async Task<IActionResult> GetPlayerById([FromRoute] int playerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PlayerDetail playerDetail = await _playerService.GetPlayerByIdAsync(playerId);
            if (playerDetail is null)
            {
                return NotFound();
            }
            return Ok(playerDetail);
        }
        [HttpPut("{playerId:int}")]
        [Authorize(Policy = "CustomAdminEntity")]
        public async Task<IActionResult> UpdatePlayerById([FromRoute] int playerId, [FromBody] PlayerUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _playerService.UpdatePlayerAsync(playerId, model)
                ? Ok("Player Was Updated")
                : BadRequest(ModelState);
        }
        [HttpDelete("{playerId:int}")]
        [Authorize(Policy = "CustomAdminEntity")]
        public async Task<IActionResult> DeletePlayerById([FromRoute] int playerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _playerService.DeletePlayerAsync(playerId)
                ? Ok("Player was Deleted")
                : BadRequest(ModelState);
        }
    }
}
