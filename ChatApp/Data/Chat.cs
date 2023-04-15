using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
