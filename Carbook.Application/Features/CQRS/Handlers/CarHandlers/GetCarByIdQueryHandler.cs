using Carbook.Application.Features.CQRS.Queries.CarQueries;
using Carbook.Application.Features.CQRS.Results.CarResults;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                CarModel=value.CarModel,
                BigImageUrl = value.BigImageUrl,
                BrandId = value.BrandId,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                Kilometer = value.Kilometer,
                Luggage = value.Luggage,
                Seat = value.Seat,
                Transmission = value.Transmission
            };
        }
    }
}
