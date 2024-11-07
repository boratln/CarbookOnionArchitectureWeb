using Carbook.Application.Features.Mediator.Commands.CarFeatureCommands;
using Carbook.Application.Interfaces.CarFeatureInterfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public CreateCarFeatureCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
             _carFeatureRepository.CreateCarFeatureByCar(new CarFeature
            {
                Available = request.Available,
                CarId = request.CarId,
                FeatureId = request.FeatureId,
            });
        }
    }
}
