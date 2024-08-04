using AutoMapper;
using ChatWave.Application.Dtos.Contacts;
using ChatWave.Application.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWave.Application.Features.Commands.Contacts
{
    public class AddToContactCommandHandler : IRequestHandler<AddToContactCommand>
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public AddToContactCommandHandler(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task Handle(AddToContactCommand request, CancellationToken cancellationToken)
        {
            var contactToAdd = _mapper.Map<ContactAddDto>(request);
            var isAdded = await _contactService.AddToContact(contactToAdd);
            if (!isAdded)
                throw new Exception("");
        }
    }
}
