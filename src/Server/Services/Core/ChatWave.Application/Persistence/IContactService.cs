using ChatWave.Application.Dtos.Contacts;
using ChatWave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Persistence
{
    public interface IContactService
    {
        Task<List<ContactListDto>> GetContacts(Guid userId);
        Task<ContactListDto> GetContactById(Guid userId, Guid contactId);
        Task<bool> AddToContact(ContactAddDto contact);
        Task<bool> RemoveFromContact(Guid userId, Guid contactId);
        Task ChangeRegisteredName(Guid userId, Guid contactId, string registeredName);
    }
}
