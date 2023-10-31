using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace server.Data
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public virtual Posts Post { get; set; }
        public virtual User User { get; set; }
    }
}
