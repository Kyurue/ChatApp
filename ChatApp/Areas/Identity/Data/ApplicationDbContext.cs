using ChatApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ChatApp.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Chat> Chats { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Chat>().HasData(
            new Chat
            {
                Id = 1,
                UserId = "e957327f-7b1d-4c97-bfca-b3ae57506a69",
                Title = "TestChat",
                Description = "Dit is een chat om te testen",
                Url = Guid.NewGuid().ToString("N").Substring(0, 10)
            },
            new Chat
            {
                Id = 2,
                UserId = "e957327f-7b1d-4c97-bfca-b3ae57506a69",
                Title = "TestChatje",
                Description = "Dit is een extra chatje om te testen",
                Url = Guid.NewGuid().ToString("N").Substring(0, 10)
            }
        );
    }
}
