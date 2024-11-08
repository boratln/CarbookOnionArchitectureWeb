using Carbook.Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ReviewsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("GetReviewsByCarId/{id}")]
		public async Task<IActionResult> GetReviewsByCarId(int id)
		{
			var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
			return Ok(values);
		}
		[HttpGet("GetReviewCountByCarId/{id}")]
		public async Task<IActionResult> GetReviewCountByCarId(int id)
		{
			var count=await _mediator.Send(new GetReviewCountQuery(id));
			return Ok(count);
		}
	}
}
