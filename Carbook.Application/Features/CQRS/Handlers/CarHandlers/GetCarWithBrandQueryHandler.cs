using Carbook.Application.Features.CQRS.Results.CarResults;
using Carbook.Application.Interfaces;
using Carbook.Application.Interfaces.CarInterfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarsListWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                CarModel=x.CarModel,
                BrandName=x.Brand.Name,
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Kilometer = x.Kilometer,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Transmission = x.Transmission
            }) .ToList();

        }
    }
}
