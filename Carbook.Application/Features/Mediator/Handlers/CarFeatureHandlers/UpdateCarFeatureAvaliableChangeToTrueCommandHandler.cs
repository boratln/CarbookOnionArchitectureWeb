using Carbook.Application.Features.Mediator.Commands.CarFeatureCommands;
using Carbook.Application.Interfaces.CarFeatureInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvaliableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvaliableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public UpdateCarFeatureAvaliableChangeToTrueCommandHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }
        public async Task Handle(UpdateCarFeatureAvaliableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
             _carFeatureRepository.ChangeCarFeatureAvaliableToTrue(request.Id);

        }
    }
}
