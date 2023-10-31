using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly BlogDbContext _blogDbContext;
        private readonly IMapper _mapper;
        public AttachmentsController(BlogDbContext blogDbContext, IMapper mapper) 
        {
            _blogDbContext = blogDbContext;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("attachmentById")]
        public Attachments GetAttachmentById([FromQuery] int id)
        {
            var attachemnt = _blogDbContext.attachments.Where(attachment => attachment.Id == id).FirstOrDefault();
            return _mapper.Map<Attachments>(attachemnt);
        }



    }
}
//api/Attachemnts/atatchemntbyid
