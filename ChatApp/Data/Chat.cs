using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Data
{
    public class Chat
    {
        [Key]
        private int Id { get; set; }
        private string? UserId { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private string Url { get; set; }

        [InverseProperty("Chat")]
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

    }
}
