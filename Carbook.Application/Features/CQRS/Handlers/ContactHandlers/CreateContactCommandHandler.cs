using Carbook.Application.Features.CQRS.Commands.ContactCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateContactCommand command)
        {
            await _repository.Create(new Contact
            {
                Name = command.Name,
                Email = command.Email,
                Message = command.Message,
                SendDate = command.SendDate,
                Subject = command.Subject,
            });
        }
    }
}
