using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models.Genres;
using webapi.Services.Genre;
using webapi.Services.Token;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly ITokenService _tokenService;

        public GenreController(IGenreService genreService, ITokenService tokenService)
        {
            _genreService = genreService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody] GenreCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool createGenre = await _genreService.CreateGenreAsync(model);
            if (createGenre == true)
            {
                return Ok("Genre Creation Sucessful");
            }
            else
            {
                return BadRequest("Genre Creation Failed");
            }
        }
        [HttpGet("GenreList")]
        public async Task<IActionResult> GetGenreList()
        {
            IEnumerable<GenreListItem> genres = await _genreService.GetGenreListAsync();
            return Ok(genres);
        }
        [HttpGet("{genreId:int}")]
        public async Task<IActionResult> GetGenreById([FromRoute] int genreId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            GenreDetail genreDetail = await _genreService.GetGenreByIdAsync(genreId);
            if (genreDetail is null)
            {
                return NotFound();
            }
            return Ok(genreDetail);
        }
        [HttpPut("{genreId:int}")]
        public async Task<IActionResult> UpdateGenreById([FromRoute] int genreId, [FromBody] GenreUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _genreService.UpdateGenreAsync(genreId, model)
                ? Ok("Genre Was Updated")
                : BadRequest(ModelState);
        }
        [HttpDelete("{genreId:int}")]
        public async Task<IActionResult> DeleteGenreById([FromRoute] int genreId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _genreService.DeleteGenreAsync(genreId)
                ? Ok("Genre was Deleted")
                : BadRequest(ModelState);
        }
    }
}
