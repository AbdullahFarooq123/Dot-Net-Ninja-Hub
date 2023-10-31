using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class LikePostCommentsModel
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public int PostId { get; set; }
    }
}
