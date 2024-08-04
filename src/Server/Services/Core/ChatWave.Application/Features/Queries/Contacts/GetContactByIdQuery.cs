using ChatWave.Application.Dtos.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Features.Queries.Contacts
{
    public class GetContactByIdQuery : IRequest<ContactListDto>
    {
        public GetContactByIdQuery()
        {
            
        }

        public GetContactByIdQuery(Guid userId, Guid contactId)
        {
            ContactId = contactId;
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public Guid ContactId { get; set; }
    }
}
