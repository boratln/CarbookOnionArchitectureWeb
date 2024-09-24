using Carbook.Application.Features.Mediator.Commands.ServicesCommands;
using Carbook.Application.Features.Mediator.Queries.ServicesQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetServicesQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _mediator.Send(new GetServicesByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateServicesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateServicesCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis başarıyla güncellendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveServicesCommand(id));
            return Ok("Servis başarıyla silindi");
        }
    }
}
