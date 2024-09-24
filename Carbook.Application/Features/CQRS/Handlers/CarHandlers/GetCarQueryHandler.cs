using Carbook.Application.Features.CQRS.Results.BrandResults;
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
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAll();
            return values.Select(x => new GetCarQueryResult
            {
                CarModel=x.CarModel,
                CarId = x.CarId,
               BigImageUrl = x.BigImageUrl,
               BrandId = x.BrandId,
               CoverImageUrl = x.CoverImageUrl,
               Fuel=x.Fuel,
               Kilometer=x.Kilometer,
               Luggage=x.Luggage,
               Seat=x.Seat,
               Transmission=x.Transmission
            }).ToList();

        }
    }
}
