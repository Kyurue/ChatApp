using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace ChatApp.Data
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(500)]
        public string Description { get; set; }
        public string Url { get; set; }
        public bool LoggedInOnly { get; set; } = false;

        [InverseProperty("Chat")]
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        public virtual ICollection<ChatMessage>? ChatMessages { get; set; }
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
