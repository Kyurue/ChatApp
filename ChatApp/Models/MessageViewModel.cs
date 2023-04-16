using ChatApp.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class MessageViewModel
    {
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Username { get; set; }

    }
}
