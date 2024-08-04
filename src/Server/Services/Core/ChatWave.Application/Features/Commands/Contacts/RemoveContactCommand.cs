using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Features.Commands.Contacts
{
    public class RemoveContactCommand : IRequest
    {
        public RemoveContactCommand()
        {
            
        }

        public RemoveContactCommand(Guid userId, Guid contactId)
        {
            ContactId = contactId;
            UserId = userId;
        }

        public Guid UserId { get; set; }
        public Guid ContactId { get; set; }
    }
}
