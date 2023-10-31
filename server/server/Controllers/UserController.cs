using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;

namespace server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;

        public UserController(BlogDbContext blogDbContext, IMapper mapper)
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUserById([FromRoute] int id)
        {
            var user = _blogDbContext.Users.SingleOrDefault(user => user.Id == id);
            if (user != null)
            {
                var userdata = _mapper.Map<User>(user);
                return Ok(userdata);
            }
            var error = "User not found";
            return BadRequest(new { error });
        }
    }
}
