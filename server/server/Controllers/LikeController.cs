using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/like")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;

        public LikeController(BlogDbContext blogDbContext, IMapper mapper)
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }

        [HttpPost]
       
        public IActionResult LikePost([FromBody] LikePostCommentsModel request)
        {
            var like = new LikePostComments
            {
                Status = request.Status,
                PostId = request.PostId
                //user id and post id 
            };
            if (like != null)
            {
                var _like = _mapper.Map<LikePostComments>(like);
                _blogDbContext.LikePostComments.Add(_like);
                _blogDbContext.SaveChanges();
                return Ok(_like);
            }
            var error = "Like is not found";
            return BadRequest(new {error});
        }

        [HttpGet]
        [Route("{id}")]
        public LikePostComments getLike([FromRoute] int id)
        {
            var like = _blogDbContext.LikePostComments.Where(like => like.Id == id).FirstOrDefault();
            return like;

        }
    }
}
