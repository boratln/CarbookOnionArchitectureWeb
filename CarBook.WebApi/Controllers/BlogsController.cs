using Carbook.Application.Features.Mediator.Commands.BlogCommands;
using Carbook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Put(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog başarıyla güncellendi");


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi");
        }
        [HttpGet("GetLast3BlogWithAuthor")]
        public async Task<IActionResult> GetLast3BlogWithAuthor()
        {
          var values=  await _mediator.Send(new GetLast3BlogWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet("GetAllBlogWithAuthor")]
        public async Task<IActionResult> GetAllBlogWithAuthor()
        {
            var values=await _mediator.Send(new GetBlogsWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet("GetByBlogWithAuthor/{id}")]
        public async Task<IActionResult> GetByBlogWithAuthor(int id)
        {
            var value=await _mediator.Send(new GetByBlogWithAuthorQuery(id));
            return Ok(value);
        }
    }
}
