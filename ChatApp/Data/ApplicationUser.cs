using Microsoft.AspNetCore.Identity;

namespace ChatApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
    }
}
