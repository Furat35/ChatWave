using ChatWave.Application.Features.Commands.Contacts;
using ChatWave.Application.Features.Queries.Contacts;
using ChatWave.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChatWave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get/{userId}")]
        public async Task<IActionResult> GetContacts(Guid userId)
        {
            var contacts = await _mediator.Send(new GetContactsQuery(userId));
            return Ok(contacts);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetContactById([FromBody] GetContactByIdQuery query)
        {
            var contact = await _mediator.Send(query);
            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(AddToContactCommand contact)
        {
            await _mediator.Send(contact);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromContact([FromBody] RemoveContactCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
