using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class Chat
    {
        [Key]
        private int id { get; set; }
        private string name { get; set; }
        private string description { get; set; }
        private string genre { get; set; }
        private string? user_id { get; set; }
        
    }
}
