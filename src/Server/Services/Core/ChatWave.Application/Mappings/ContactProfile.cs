using AutoMapper;
using ChatWave.Application.Dtos.Contacts;
using ChatWave.Application.Features.Commands.Contacts;
using ChatWave.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Mappings
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<AddToContactCommand, ContactAddDto>();
            CreateMap<ContactAddDto, Contact>();
            CreateMap<Contact, ContactListDto>();
        }
    }
}
