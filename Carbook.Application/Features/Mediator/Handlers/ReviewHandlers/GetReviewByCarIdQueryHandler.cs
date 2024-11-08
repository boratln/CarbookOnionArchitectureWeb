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
	public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _reviewRepository;

		public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _reviewRepository.GetReviewsByCarId(request.Id);
			return values.Select(x => new GetReviewByCarIdQueryResult
			{
				CarId = x.CarId,
				Comment = x.Comment,
				CustomerImageUrl = x.CustomerImageUrl,
				CustomerName = x.CustomerName,
				Rating = x.Rating,
				Rating_Date = x.Rating_Date,
				ReviewId = x.ReviewId
			}).ToList();
		}
	}
}
