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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _repository.GetById(command.ContactId);
            value.Name = command.Name;
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Message = command.Message;
            await _repository.Update(value);
        }
    }
}
