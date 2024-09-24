using Carbook.Application.Features.CQRS.Commands.CarCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await _repository.Create(new Car
            {
                CarModel = command.CarModel,
                BigImageUrl = command.BigImageUrl,
                BrandId = command.BrandId,
                CoverImageUrl = command.CoverImageUrl,
                Fuel = command.Fuel,
                Kilometer = command.Kilometer,
                Luggage = command.Luggage,
                Seat = command.Seat,
                Transmission = command.Transmission,
               

            });
        }
    }
}
