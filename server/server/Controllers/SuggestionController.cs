using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/suggestion")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;
        public SuggestionController(BlogDbContext blogDbContext, IMapper mapper)
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("{id}")]
        public IActionResult addSuggestion([FromBody] SuggestionsModel request, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First().ErrorMessage;
                return BadRequest(new { error });
            }
            var suggest = new Suggestions
            {
                Content = request.Content,
                Id = id,
                IsApproved = request.IsApproved,
                
            };
            var suggestion_ = _mapper.Map<Suggestions>(suggest);
            _blogDbContext.suggestions.Add(suggestion_);
        
            return Ok(suggest);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult CheckSuggestion([FromRoute]int id)
        {
            var suggestions = _blogDbContext.suggestions
                .Where(s => s.Id == id && !s.IsApproved)
                .ToList();

            return Ok(suggestions);


        }

    }
}
