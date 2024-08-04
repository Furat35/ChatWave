using ChatWave.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Features.Commands.Contacts
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
    {
        private readonly IContactService _contactService;

        public RemoveContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var isRemoved = await _contactService.RemoveFromContact(request.UserId, request.ContactId);
            if (!isRemoved)
                throw new Exception("");
        }
    }
}
