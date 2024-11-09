using Carbook.Application.Features.Mediator.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignUpController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SignUpController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser(CreateAppUserCommand command) {
			await _mediator.Send(command);
			return Ok("Kullanıcı başarıyla oluşturuldu");
		}
	}
}
