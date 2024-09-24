using Carbook.Application.Features.Mediator.Commands.FeatureCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler:IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _Repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _Repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _Repository.GetById(request.Id);
            await _Repository.Remove(value);
        }
    }
}
