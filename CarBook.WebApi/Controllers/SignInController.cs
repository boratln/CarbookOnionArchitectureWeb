using Carbook.Application.Features.Mediator.Queries.AppUserQueries;
using Carbook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SignInController : ControllerBase
	{
		private readonly IMediator _mediator;

		public SignInController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		public async Task <IActionResult> Login(GetCheckAppUserQuery query)
		{
			var values = await _mediator.Send(query);
			if (values.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(values));
			}
			else
			{
				return BadRequest("Kullanıcı Adı veya Şifre hatalı");
			}
		}
	}
}
