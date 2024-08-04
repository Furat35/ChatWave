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
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<ContactListDto>>
    {
        private readonly IContactService _contactService;

        public GetContactsQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<List<ContactListDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _contactService.GetContacts(request.UserId);
            return contacts;
        }
    }
}
