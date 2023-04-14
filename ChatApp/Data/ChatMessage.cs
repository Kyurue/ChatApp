using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Data
{
    public class ChatMessage
    {
        [Key]
        private int Id { get; set; }
        private string? UserId { get; set; }
        private int ChatId { get; set; }
        private string Message { get; set; }

        [ForeignKey(nameof(ChatId))]
        public virtual Chat Chat { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual IdentityUser IdentityUser { get; set; }

    }
}
