using Carbook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsPricingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarsPricingsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet]
		public async  Task<IActionResult> GetAllCarPricings()
		{
			var values=await _mediator.Send(new GetCarPricingQuery());
			return Ok(values);
		}
		[HttpGet("GetCarPricingWithTimePeriodList")]
		public async Task<IActionResult> GetCarPricingWithTimePeriodList()
		{
			var values = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
			return Ok(values);
		}
	}
}

