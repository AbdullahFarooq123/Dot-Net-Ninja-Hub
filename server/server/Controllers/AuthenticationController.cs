using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;
using server.Helpers;

namespace server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;
        public AuthenticationController(BlogDbContext blogDbContext, IMapper mapper)
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First().ErrorMessage;
                return BadRequest(new { error });
            }   
            var login = _blogDbContext.Users.Where(user => user.Email == request.Email && request.Password == request.Password).FirstOrDefault();
            
            if (login != null)
            {
                var jwt = new GenerateJWT();
                var token = jwt.GenerateJwtToken(login.Email);

                // Return the token and user data
                return Ok(new { token, user = login });
            }
            var error2 = "incorrect email and password";
            return BadRequest(new {error2});
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Signup([FromBody] SignupModel request)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First().ErrorMessage;
                return BadRequest(new { error });
            }
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
            };
            //var _user = _mapper.Map<User>(user);
            _blogDbContext.Users.Add(user);
            _blogDbContext.SaveChanges();
            return Ok();
        }


    }
}
