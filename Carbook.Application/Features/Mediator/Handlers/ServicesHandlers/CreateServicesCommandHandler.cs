using Carbook.Application.Features.Mediator.Commands.ServicesCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.ServicesHandlers
{
    public class CreateServicesCommandHandler:IRequestHandler<CreateServicesCommand>
    {
        private readonly IRepository<Carbook.Domain.Entities.Services> _repository;

        public CreateServicesCommandHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServicesCommand request, CancellationToken cancellationToken)
        {
            await _repository.Create(new Domain.Entities.Services
            {
                Description = request.Description,
                IconUrl = request.IconUrl,
                Title = request.Title,
            });
        }
    }
}
