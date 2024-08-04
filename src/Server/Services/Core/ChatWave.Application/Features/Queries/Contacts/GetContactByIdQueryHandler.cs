using ChatWave.Application.Dtos.Contacts;
using ChatWave.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Features.Queries.Contacts
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactListDto>
    {
        private readonly IContactService _contactService;

        public GetContactByIdQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<ContactListDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactService.GetContactById(request.UserId, request.ContactId);
            return contact;
        }
    }
}
