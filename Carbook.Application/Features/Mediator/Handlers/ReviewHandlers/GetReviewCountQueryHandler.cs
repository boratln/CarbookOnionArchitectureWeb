using Carbook.Application.Features.Mediator.Queries.ReviewQueries;
using Carbook.Application.Features.Mediator.Results.ReviewResults;
using Carbook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewCountQueryHandler : IRequestHandler<GetReviewCountQuery, GetReviewCountQueryResult>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewCountQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<GetReviewCountQueryResult> Handle(GetReviewCountQuery request, CancellationToken cancellationToken)
		{
			var count =  _reviewRepository.ReviewCount(request.Id);
			return new GetReviewCountQueryResult
			{
				ReviewCount = count
			};
		}
	}
}
