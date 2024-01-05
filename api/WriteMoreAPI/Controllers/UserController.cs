using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WriteMore.Application.DTOs.Request;
using WriteMore.Application.DTOs.Response;
using WriteMore.Application.Interfaces.Services;

namespace WriteMore.API.Controllers
{
    public class UserController: Controller
    {
        private IIdentityService _identityService;
        public UserController(IIdentityService identityService) => _identityService = identityService;

        [HttpPost("/user/register")]
        public async Task<ActionResult<RegisterUserResponse>> Register([FromBody]RegisterUserRequest request)
        {
            var result = await _identityService.RegisterUser(request);
            if (result.Success)
                return Ok(result);
            else if (result.Errors.Count > 0)
                return BadRequest(result);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("/user/login")]
        public async Task<ActionResult<LoginUserResponse>> Login([FromBody]LoginUserRequest request)
        {
            var result = await _identityService.Login(request);
            if (result.Success)
                return Ok(result);
            return Unauthorized(result);
        }

        [Authorize]
        [HttpPost("refresh-login")]
        public async Task<ActionResult<LoginUserResponse>> RefreshLogin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();
            var result = await _identityService.LoginWhithoutPassword(userId);
            if (result.Success)
                return Ok(result);
            return Unauthorized();
        }
    }
}
