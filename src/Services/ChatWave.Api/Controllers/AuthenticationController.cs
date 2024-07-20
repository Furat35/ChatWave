using ChatWave.Application.Features.Commands.Authentications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatWave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand loginUser)
        {
            var loginResponse = await _mediator.Send(loginUser);
            return Ok(loginResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand registerUser)
        {
            var userId = await _mediator.Send(registerUser);
            return Ok(userId);
        }
    }
}
