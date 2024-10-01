using Carbook.Application.Features.Mediator.Commands.TagCloudCommands;
using Carbook.Application.Features.Mediator.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetTagCloudQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("Etiket Bulutu başarıyla güncellendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("Etiket Bulutu başarıyla silindi");
        }
        [HttpGet("GetTagCloudByBlogId/{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var values=await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(values);
        }
    }
}
