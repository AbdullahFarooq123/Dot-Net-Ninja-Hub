using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class LikePostComments
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public int? PostId { get; set; }
        public Posts post { get; set; }
        public User user { get; set; }
    }
}
