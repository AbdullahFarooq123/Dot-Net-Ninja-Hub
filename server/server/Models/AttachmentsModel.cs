using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class AttachmentsModel
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool Status { get; set; }

    }
}
