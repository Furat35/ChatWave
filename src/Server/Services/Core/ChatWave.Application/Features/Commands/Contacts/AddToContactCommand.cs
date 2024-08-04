using ChatWave.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatWave.Application.Features.Commands.Contacts
{
    public class AddToContactCommand : IRequest
    {
        public Guid ContactUserId { get; set; }
        public string RegisteredName { get; set; }
        public Guid UserId { get; set; }
    }
}
