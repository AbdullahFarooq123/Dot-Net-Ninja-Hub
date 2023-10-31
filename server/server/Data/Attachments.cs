using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace server.Data
{
    public class Attachments
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool Status { get; set; }
        public Posts Post { get; set; }
    }
}
