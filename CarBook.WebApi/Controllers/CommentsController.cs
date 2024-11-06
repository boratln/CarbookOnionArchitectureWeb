using Carbook.Application.Features.Mediator.Commands.CommentCommands;
using Carbook.Application.Features.RepositoryPattern.CommentRepositories;
using Carbook.Domain.Entities;
using Carbook.Persistence.Repositories.CommentRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;
        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get() { 
        var list=_commentRepository.GetAll();
            return Ok(list);
        }
        [HttpGet("CommentCountByBlogId/{blogid}")]
        public IActionResult Count(int blogid)
        {
            var list=_commentRepository.Count(blogid);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(Comment comment)
        {
             _commentRepository.Create(comment);
            return Ok("Başarıyla yorum eklendi");
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
        var value=_commentRepository.GetCommentsByBlogId(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult Put(Comment comment) {
        _commentRepository.Update(comment);
            return Ok("Yorum başarıyla güncellendi");
        }
        [HttpDelete]
        public IActionResult Delete(int id) {
            var value = _commentRepository.GetById(id);
            _commentRepository.Remove(value);
            return Ok("Yorum başarıyla silindi");
        
        }
        [HttpGet("CommentListByBlog/{id}")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _commentRepository.GetCommentsByBlogId(id);
            return Ok(value);
        }
        [HttpPost("AddComment")]
        public async Task<IActionResult> AddComment(CreateCommentCommand command)
        {
           await _mediator.Send(command);
            return Ok("Yorum başarıyla eklendi");
        }
    }
}
