using Carbook.Application.Features.Mediator.Commands.ReviewCommands;
using Carbook.Application.Features.Mediator.Queries.ReviewQueries;
using Carbook.Application.Validaters.ReviewValidater;
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
		[HttpPost]
		public async Task<IActionResult> CreateReview(CreateReviewCommand command)
		{
			CreateReviewValidator validator = new CreateReviewValidator();
			var validatorresult= validator.Validate(command);
			if (!validatorresult.IsValid)
			{
				return BadRequest(validatorresult.Errors);
			}
			else
			{
				await _mediator.Send(command);
				return Ok("Ekleme İşlemi Gerçekleşti");
			}
			
		}
		[HttpPut]
		public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
		{
			
			UpdateReviewValidator validator = new UpdateReviewValidator();
			var validatorresult=validator.Validate(command);
			if (!validatorresult.IsValid)
			{
				return BadRequest(validatorresult.Errors);
			}
			else
			{
				await _mediator.Send(command);
				return Ok("Güncelleme İşlemi Gerçekleşti");
			}
			
		}
	}
}
