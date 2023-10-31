using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;
        public PostsController(BlogDbContext blogDbContext, IMapper mapper)
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }
        [HttpPost]
        //[Authorize]
        [Route("")]
        public IActionResult addPost([FromBody] PostsModel request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First().ErrorMessage;
                return BadRequest(new { error });
            }
            var post = new Posts
            {
                Content = request.Content,
                Title = request.Title,
                //UserID = request.UserID,
                IsReported = false,
                Status = false,
            };
            
            _mapper.Map<Posts>(post);
            _blogDbContext.Posts.Add(post);
            _blogDbContext.SaveChanges();
            return Ok(post);
        }

        [HttpGet]
        [Route("{id}")]
        public Posts showPost([FromRoute] int id)
        {
            var post = _blogDbContext.Posts.Where(post => post.Id == id).FirstOrDefault();
            return _mapper.Map<Posts>(post);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult findAllPost()
        {
            var post = _blogDbContext.Posts;
            
                return Ok(post.ToList());
            
            //var error = "empty posts";
            //return BadRequest(new { error });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _blogDbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound(new { error = "Post not found" });
            }

            _blogDbContext.Posts.Remove(post);
            await _blogDbContext.SaveChangesAsync();

            return Ok(_mapper.Map<Posts>(post));
        }

        [HttpPut("approve/{id}")]
        public async Task<IActionResult> ApprovePost(int id)
        {
            var post = await _blogDbContext.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound(new { error = "Post not found" });
            }

            post.Status = true;

            _blogDbContext.Posts.Update(post);
            await _blogDbContext.SaveChangesAsync();

            return Ok(_mapper.Map<Posts>(post));
        }
        //[HttpGet("reported")]
        //public async Task<IActionResult> ShowReportedPosts()
        //{
        //    var reportedPosts = await _blogDbContext.Posts
        //        .Where(post => post.IsReported)
        //        .Include(post => post.Attachments)
        //        .ToListAsync();

        //    if (reportedPosts == null || reportedPosts.Count == 0)
        //    {
        //        return NotFound(new { error = "No reported posts found" });
        //    }

        //    return Ok(reportedPosts);
        //}
    }
}
