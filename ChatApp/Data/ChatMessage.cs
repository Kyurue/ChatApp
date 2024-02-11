using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChatApp.Data
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int ChatId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(ChatId))]
        public virtual Chat Chat { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}