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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            var value = await _repository.GetById(command.CarId);
            value.CarModel = command.CarModel;
            value.Fuel = command.Fuel;
            value.Transmission = command.Transmission;
            value.BigImageUrl = command.BigImageUrl;
            value.BrandId = command.BrandId;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Luggage=command.Luggage;
            value.Seat = command.Seat;
            value.Kilometer=command.Kilometer;
            await _repository.Update(value);
        }
    }
}
