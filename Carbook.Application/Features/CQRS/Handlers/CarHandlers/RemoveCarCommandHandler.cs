using Carbook.Application.Features.CQRS.Commands.CarCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {

            _repository = repository;
        }
        public async Task Handle(RemoveCarCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Remove(value);
        }
    }
}
