using Carbook.Application.Features.Mediator.Commands.AuthorCommands;
using Carbook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yazar başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yazar başarıyla güncellendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Yazar başarıyla silindi");
        }
    }
}
