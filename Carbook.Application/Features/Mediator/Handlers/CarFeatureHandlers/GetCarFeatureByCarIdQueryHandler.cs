using Carbook.Application.Features.Mediator.Queries.CarFeatureQueries;
using Carbook.Application.Features.Mediator.Results.CarFeatureResults;
using Carbook.Application.Interfaces;
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
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async  Task< List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
        
            var values =  await _carFeatureRepository.GetCarFeatureByCarId(request.Id);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                Available = x.Available,
                CarFeatureId = x.CarFeatureId,
                CarId = x.CarId,
                FeatureId = x.FeatureId,
                FeatureName = x.Feature.Name,
                CarModel=x.Car.CarModel
               
            }).ToList();

        }
    }
}
