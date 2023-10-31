using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;
        public CommentController(BlogDbContext blogDbContext, IMapper mapper)
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }

        [HttpPost]

        public IActionResult addComment([FromBody] CommentsModel request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First().ErrorMessage;
                return BadRequest(new { error });
            }
            var comment = new CommentsModel
            {
                Content = request.Content,
            };
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteComment([FromQuery] int id)
        {
            var comment = _blogDbContext.Comments.Find(id);
            if (comment != null)
            {
                _blogDbContext.Comments.Remove(comment);
                _blogDbContext.SaveChanges();
                return Ok();
            }
            var error = "Id not found";
            return BadRequest(new {error});
        }

        [HttpGet]
        public IActionResult GetComment([FromQuery] int id)
        {
            var comment = _blogDbContext.Comments.Where(comment => comment.Id == id).FirstOrDefault();
            if (comment != null)
            {
                var comments = _mapper.Map<Comments>(comment);
                return Ok(comments);
            }
            var error = "Comment not found";
            return BadRequest(new {error});
        }
    }
}
