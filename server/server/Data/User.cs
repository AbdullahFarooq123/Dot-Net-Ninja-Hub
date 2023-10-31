using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Suggestions> Suggestions { get; set; }
        public virtual ICollection<LikePostComments> Likes { get; set; }
    }
}
