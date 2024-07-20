using ChatWave.Application.Features.Commands.Users;
using ChatWave.Application.Features.Queries.Users;
using ChatWave.Application.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatWave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetUsers([FromQuery] UserRequestFilter filters)
        {
            var users = await _mediator.Send(new GetUsersQuery(filters));
            return Ok(users);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand model)
        {
            var userId = await _mediator.Send(model);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] CreateUserCommand model)
        {
            await _mediator.Send(new UpdateUserCommand());
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok();
        }
    }
}
