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
	public class RemoveCarDescriptionCommandHandler : IRequestHandler<RemoveCarDescriptionCommand>
	{
		private readonly IRepository<CarDescription> _repository;

		public RemoveCarDescriptionCommandHandler(IRepository<CarDescription> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCarDescriptionCommand request, CancellationToken cancellationToken)
		{
			var value=await _repository.GetById(request.Id);
			await _repository.Remove(value);

		}
	}
}
