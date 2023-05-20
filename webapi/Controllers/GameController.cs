using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models.Games;
using webapi.Models.Games;
using webapi.Services.Game;
using webapi.Services.Token;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ITokenService _tokenService;

        public GameController(IGameService gameService, ITokenService tokenService)
        {
            _gameService = gameService;
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool createGame = await _gameService.CreateGameAsync(model);
            if (createGame == true)
            {
                return Ok("Game Creation Sucessful");
            }
            else
            {
                return BadRequest("Game Creation Failed");
            }
        }
        [HttpGet("GameList")]
        public async Task<IActionResult> GetGameList(int creatorId)
        {
            IEnumerable<GameListItem> games = await _gameService.GetGameListByCreatorAsync(creatorId);
            return Ok(games);
        }
        [HttpGet("{gameId:int}")]
        public async Task<IActionResult> GetGameById([FromRoute] int gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GameDetail gameDetail = await _gameService.GetGameByIdAsync(gameId);
            if (gameDetail is null)
            {
                return NotFound();
            }
            return Ok(gameDetail);
        }
        [HttpPut("{gameId:int}")]
        public async Task<IActionResult> UpdateGameById([FromRoute] int gameId, [FromBody] GameUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _gameService.UpdateGameAsync(gameId, model)
                ? Ok("Game Was Updated")
                : BadRequest(ModelState);
        }
        [HttpDelete("{gameId:int}")]
        public async Task<IActionResult> DeleteGameById([FromRoute] int gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _gameService.DeleteGameAsync(gameId)
                ? Ok("Game was Deleted")
                : BadRequest(ModelState);
        }
    }
}
