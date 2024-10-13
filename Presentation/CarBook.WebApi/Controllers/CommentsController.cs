using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistance.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _genericRepository;

        public CommentsController(IGenericRepository<Comment> genericRepository)
        {
            _genericRepository=genericRepository;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _genericRepository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            
            _genericRepository.Create(comment);
            return Ok("Yorum Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value= _genericRepository.GetById(id);
            _genericRepository.Remove(value);
            return Ok("Yorum Silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _genericRepository.Update(comment);
            return Ok("Yorum Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _genericRepository.GetById(id);
            return Ok(value);
        }
    }
}

