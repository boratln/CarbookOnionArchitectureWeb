using Carbook.Application.Features.RepositoryPattern.CommentRepositories;
using Carbook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }
        [HttpGet]
        public IActionResult Get() { 
        var list=_commentRepository.GetAll();
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
    }
}
