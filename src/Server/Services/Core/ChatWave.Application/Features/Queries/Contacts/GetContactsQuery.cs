using ChatWave.Application.Dtos.Contacts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Features.Queries.Contacts
{
    public class GetContactsQuery : IRequest<List<ContactListDto>>
    {
        public GetContactsQuery()
        {
            
        }

        public GetContactsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }
}
