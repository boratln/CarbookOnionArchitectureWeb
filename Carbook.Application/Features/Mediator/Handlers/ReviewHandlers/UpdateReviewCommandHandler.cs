using Carbook.Application.Features.Mediator.Commands.ReviewCommands;
using Carbook.Application.Features.Mediator.Commands.ReviewCommands;
using Carbook.Application.Interfaces;
using Carbook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewCommandHandler:IRequestHandler<UpdateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public UpdateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetById(request.ReviewId);
			value.CustomerName = request.CustomerName;
			value.Comment = request.Comment;
			value.CarId= request.CarId;
			value.Rating_Date = request.Rating_Date;
			value.Rating = request.Rating;

			await _repository.Update(value);
		}
	}
}
