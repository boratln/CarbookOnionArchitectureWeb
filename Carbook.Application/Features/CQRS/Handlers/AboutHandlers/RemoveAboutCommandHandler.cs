using Carbook.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbook.Domain.Entities;
using Carbook.Application.Features.CQRS.Commands.AboutCommands;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutCommand command)
        {
            var value=await _repository.GetById(command.Id);
            await _repository.Remove(value);

        }
    }
}
