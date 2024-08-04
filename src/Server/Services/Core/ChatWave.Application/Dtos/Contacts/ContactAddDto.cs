using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Dtos.Contacts
{
    public class ContactAddDto
    {
        public Guid UserId { get; set; }
        public Guid ContactUserId { get; set; }
        public string RegisteredName { get; set; }
    }
}
