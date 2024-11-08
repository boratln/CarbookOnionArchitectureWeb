using Carbook.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Queries.ReviewQueries
{
	public class GetReviewCountQuery:IRequest<GetReviewCountQueryResult>
	{
		public int Id {  get; set; }

		public GetReviewCountQuery(int ıd)
		{
			Id = ıd;
		}
	}
}
