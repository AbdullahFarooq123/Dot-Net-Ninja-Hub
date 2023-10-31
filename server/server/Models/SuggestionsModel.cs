using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class SuggestionsModel
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Reply { get; set; }
        public bool IsApproved { get; set; }

        public int UserID { get; set; }

        public int PostID { get; set; }
    }
}
