using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Models.Creators;
using webapi.Services.Creator;
using webapi.Services.Token;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CreatorController : ControllerBase
    {
        private readonly ICreatorService _creatorService;
        private readonly ITokenService _tokenService;

        public CreatorController(ICreatorService creatorService, ITokenService tokenService)
        {
            _creatorService = creatorService;
            _tokenService = tokenService;
        }
        [HttpPost]
        [Authorize(Policy = "CustomAdminEntity")]
        public async Task<IActionResult> CreateCreator([FromBody] CreatorCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool createCreator = await _creatorService.CreateCreatorAsync(model);
            if (createCreator == true)
            {
                return Ok("Creator Creation Sucessful");
            }
            else
            {
                return BadRequest("Creator Creation Failed");
            }
        }
        [HttpGet("CreatorList")]
        public async Task<IActionResult> GetCreatorList()
        {
            IEnumerable<CreatorListItem> creators = await _creatorService.GetCreatorListAsync();
            return Ok(creators);
        }
        [HttpGet("{creatorId:int}")]
        public async Task<IActionResult> GetCreatorById([FromRoute] int creatorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CreatorDetail CreatorDetail = await _creatorService.GetCreatorByIdAsync(creatorId);
            if (CreatorDetail is null)
            {
                return NotFound();
            }
            return Ok(CreatorDetail);
        }
        [HttpPut("{creatorId:int}")]
        [Authorize(Policy = "CustomAdminEntity")]
        public async Task<IActionResult> UpdateCreatorById([FromRoute] int creatorId,[FromBody] CreatorUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _creatorService.UpdateCreatorAsync(creatorId, model)
                ? Ok("Creator Was Updated")
                : BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "CustomAdminEntity")]
        public async Task<IActionResult> DeleteCreatorById([FromRoute] int creatorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _creatorService.DeleteCreatorAsync(creatorId)
                ? Ok("Creator was Deleted")
                : BadRequest(ModelState);
        }
    }
}
