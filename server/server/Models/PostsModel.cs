using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace server.Models
{
    public class PostsModel
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsReported { get; set; }
        public bool Status { get; set; }
        public int UserID { get; set; }
    }
}
