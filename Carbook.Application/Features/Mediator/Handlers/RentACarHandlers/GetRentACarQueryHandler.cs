using Carbook.Application.Features.Mediator.Queries.RentACarQueries;
using Carbook.Application.Features.Mediator.Results.RentACarResults;
using Carbook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentacarepository;

        public GetRentACarQueryHandler(IRentACarRepository rentacarepository)
        {
            _rentacarepository = rentacarepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentacarepository.GetByFilter(x => x.LocationId == request.LocationId && x.Avaliable == true);
            var results = values.Select(y => new GetRentACarQueryResult
            {
                CarId = y.CarId,
                BrandName = y.Car.Brand.Name,
                CarModel = y.Car.CarModel,
                CoverImageUrl = y.Car.CoverImageUrl,

            }).ToList();       
                return results;
        }
    }
}
