using server.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace server.Data
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsReported { get; set; }
        public bool Status { get; set; }


        public ICollection<Comments> Comments { get; set; }
        public  ICollection<Attachments> Attachments { get; set; }
        public  ICollection<Suggestions> Suggestions { get; set; }
        public  ICollection<LikePostComments> Likes { get; set; }
    }
}
