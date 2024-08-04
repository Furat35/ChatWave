using AutoMapper;
using ChatWave.Application.Dtos.Contacts;
using ChatWave.Application.Exceptions;
using ChatWave.Application.Persistence;
using ChatWave.Application.Persistence.Repository;
using ChatWave.Application.UnitOfWorks;
using ChatWave.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Infrastructure.Persistence
{
    public class ContactService : IContactService
    {
        private readonly IBaseRepository<Contact> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _contactRepository = unitOfWork.GetRepository<Contact>();
            _mapper = mapper;
        }

        public async Task<List<ContactListDto>> GetContacts(Guid userId)
        {
            var contacts = await (await _contactRepository.GetAllAsync(_ => _.UserId == userId)).Select(_ => new ContactListDto()
            {
                ContactUserId = _.ContactUserId,
                RegisteredName = _.RegisteredName
            }).ToListAsync();

            return contacts;
        }

        public async Task<ContactListDto> GetContactById(Guid userId, Guid contactId)
        {
            var contact = await _contactRepository.GetSingleAsync(c => c.ContactUserId == contactId && c.UserId == userId);
            if (contact is null)
                throw new NotFoundException($"User with id : {contactId} could not be found!");

            return _mapper.Map<ContactListDto>(contact);
        }

        public async Task<bool> AddToContact(ContactAddDto contact)
        {
            var contactExists = await _contactRepository.Exists(_ => _.ContactUserId == contact.ContactUserId);
            if (contactExists)
                throw new BadRequestException("Contact already exists!");
            var addedContact = _mapper.Map<Contact>(contact);
            var effectedRows = await _contactRepository.AddAsync(addedContact);

            return effectedRows > 0;
        }

        public async Task<bool> RemoveFromContact(Guid userId, Guid contactId)
        {
            var contact = await _contactRepository.GetSingleAsync(_ => _.ContactUserId == contactId && _.UserId == userId);
            if (contact is null)
                throw new NotFoundException($"Contact with id : {contactId} not found!");
            var effectedRows = await _contactRepository.DeleteAsync(contact);

            return effectedRows > 0;
        }

        public async Task ChangeRegisteredName(Guid userId,Guid contactId, string registeredName)
        {
            var contact = await _contactRepository.GetByIdAsync(contactId);
            contact.RegisteredName = registeredName;
            await _contactRepository.UpdateAsync(contact);
        }
    }
}
