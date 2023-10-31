using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data
{
    public class Suggestions
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Reply { get; set; }
        public bool IsApproved { get; set; }
        public virtual User User { get; set; }
        public virtual Posts post { get; set; }

    }
}
