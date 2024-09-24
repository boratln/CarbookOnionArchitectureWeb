using Carbook.Application.Features.Mediator.Queries.FooterAddressQueries;
using Carbook.Application.Features.Mediator.Commands.FooterAddressCommands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adresi başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer Adresi başarıyla güncellendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Footer Adresi başarıyla silindi");
        }
    }
}
