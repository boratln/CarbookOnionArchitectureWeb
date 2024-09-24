using Carbook.Application.Features.Mediator.Commands.ServicesCommands;
using Carbook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class RemoveServicesCommandHandler : IRequestHandler<RemoveServicesCommand>
    {
        private readonly IRepository<Carbook.Domain.Entities.Services> _repository;

        public RemoveServicesCommandHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveServicesCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            await _repository.Remove(value);
        }
    }
}
