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
    public class UpdateServicesCommandHandler : IRequestHandler<UpdateServicesCommand>
    {
        private readonly IRepository<Carbook.Domain.Entities.Services> _repository;

        public UpdateServicesCommandHandler(IRepository<Domain.Entities.Services> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.ServicesId);
           value.Title = request.Title;
            value.Description = request.Description;
            value.IconUrl = request.IconUrl;

            await _repository.Update(value);
        }
    }
}
