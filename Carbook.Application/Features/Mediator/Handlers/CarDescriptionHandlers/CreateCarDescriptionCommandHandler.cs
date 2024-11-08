using Carbook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand>
	{
		private readonly IRepository<CarDescription> _repository;

		public CreateCarDescriptionCommandHandler(IRepository<CarDescription> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
		{
			await _repository.Create(new CarDescription
			{
				CarId= request.CarId,
				Details= request.Details
			});
		}
	}
}
