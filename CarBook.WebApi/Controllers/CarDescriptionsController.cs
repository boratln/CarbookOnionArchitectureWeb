using Carbook.Application.Features.Mediator.Commands.CarDescriptionCommands;
using Carbook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDescriptionsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDescriptionsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("GetCarDescriptionByCarId/{id}")]
		public async Task<IActionResult> GetCarDescriptionByCarId(int id)
		{
			var value = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
			return Ok(value);
		}
		[HttpPost("CreateCarDescription")]
		public async Task<IActionResult> CreateCarDescription(CreateCarDescriptionCommand command)
		{
			await _mediator.Send(command);
			return Ok("Araba Açıklaması başarıyla eklendi");
		}
	}
}
