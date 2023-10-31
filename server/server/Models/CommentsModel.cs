using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class CommentsModel
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
