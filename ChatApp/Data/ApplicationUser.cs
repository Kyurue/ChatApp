using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        [InverseProperty("ApplicationUser")]
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        [InverseProperty("ApplicationUser")]
        public virtual ICollection<Chat> Chats { get; set; }
    }
}
