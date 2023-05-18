using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.Data.Entities;
using webapi.Models.Login;
using webapi.Models.Token;
using webapi.Services.Login;
using webapi.Services.Token;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly ITokenService _tokenService;

        public LoginController(ILoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CreateLogin([FromBody] LoginCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool createLogin = await _loginService.CreateLoginAsync(model);
            if (createLogin == true)
            {
                return Ok("Login Creation Sucessful");
            }
            else
            {
                return BadRequest("Login Creation Failed");
            }
        }
        [HttpPost("TokenAdmin")]
        public async Task<IActionResult> TokenAdmin([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TokenResponse tokenResponse = await _tokenService.GetTokenAsync<AdminEntity>(request);
            if (tokenResponse is null)
            {
                return BadRequest("invalid username or password");
            }
            return Ok(tokenResponse);
        }
        [HttpPost("TokenUser")]
        public async Task<IActionResult> TokenUser([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TokenResponse tokenResponse = await _tokenService.GetTokenAsync<UserEntity>(request);
            if (tokenResponse is null)
            {
                return BadRequest("invalid username or password");
            }
            return Ok(tokenResponse);
        }
        [HttpGet("LoginList")]
        public async Task<IActionResult> GetLoginList()
        {
            IEnumerable<LoginListItem> logins = await _loginService.GetLoginListAsync();
            return Ok(logins);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLoginById([FromRoute] int id)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            LoginDetail loginDetail = await _loginService.GetLoginByIdAsync(id);
            if (loginDetail is null)
            {
                return NotFound();
            }
            return Ok(loginDetail);
        }
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpPut]
        public async Task<IActionResult> UpdateLoginInfoById([FromBody] LoginUpdate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _loginService.UpdateLoginAsync(model)
                ? Ok("Login Was Updated") 
                : BadRequest(ModelState);
        }
        [Authorize(Policy = "CustomAdminEntity")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLoginById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _loginService.DeleteLoginAsync(id)
                ? Ok("Login was Deleted") 
                : BadRequest(ModelState);
        }
    }
}
