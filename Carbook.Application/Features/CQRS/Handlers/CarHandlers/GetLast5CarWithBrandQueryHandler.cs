using Carbook.Application.Features.CQRS.Results.CarResults;
using Carbook.Application.Interfaces;
using Carbook.Application.Interfaces.CarInterfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler 
    {
        private readonly ICarRepository _repository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetLast5CarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetLast5CarsWithBrand();
            return values.Select(x => new GetLast5CarWithBrandQueryResult
            {
                CarModel = x.CarModel,
                BrandName = x.Brand.Name,
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                BrandId = x.BrandId,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Kilometer = x.Kilometer,
                Luggage = x.Luggage,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();

        }

    }
}
