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
	public class CreateReviewCommandHandler:IRequestHandler<CreateReviewCommand>
	{
		private readonly IRepository<Review> _repository;

		public CreateReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			await _repository.Create(new Review
			{
				CarId = request.CarId,
				Comment = request.Comment,
				CustomerImageUrl = request.CustomerImageUrl,
				CustomerName = request.CustomerName,
				Rating = request.Rating,
				Rating_Date = DateTime.Parse(DateTime.Now.ToShortDateString())
				
			
			});
		}
	}
}
