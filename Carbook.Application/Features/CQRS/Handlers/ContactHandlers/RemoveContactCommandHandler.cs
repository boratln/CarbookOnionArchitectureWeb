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
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {

            _repository = repository;
        }
        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }
    }
}
