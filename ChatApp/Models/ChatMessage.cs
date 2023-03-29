using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class ChatMessage
    {
        [Key]
        private int id { get; set; }
        private int chat_id { get; set; }
        private string message { get; set; }
        private string? user_id { get; set; }
    }
}
