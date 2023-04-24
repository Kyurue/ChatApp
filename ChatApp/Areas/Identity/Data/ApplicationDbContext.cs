using ChatApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ChatApp.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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
                UserId = "3dede8f3-0bf4-42af-83fa-f3a52f42b70f",
                Title = "TestChat",
                Description = "Dit is een chat om te testen",
                Url = Guid.NewGuid().ToString("N").Substring(0, 10),
                LoggedInOnly = false
            },
            new Chat
            {
                Id = 2,
                UserId = "3dede8f3-0bf4-42af-83fa-f3a52f42b70f",
                Title = "TestChatje",
                Description = "Dit is een extra chatje om te testen",
                Url = Guid.NewGuid().ToString("N").Substring(0, 10),
                LoggedInOnly = false
            },
            new Chat
            {
                Id = 3,
                UserId = "3dede8f3-0bf4-42af-83fa-f3a52f42b70f",
                Title = "TestChatt",
                Description = "Dit is een extra chatttt om te testen",
                Url = Guid.NewGuid().ToString("N").Substring(0, 10),
                LoggedInOnly = false
            }
        );

        modelBuilder.Entity<ChatMessage>().HasData(
            new ChatMessage
            {
                Id = 1,
                UserId = "3dede8f3-0bf4-42af-83fa-f3a52f42b70f",
                ChatId = 1,
                Message = "Hi, dit is een test bericht, ik wil even testen wat er gebeurd zodra dit bericht vrij lang word :o",
                CreatedAt = DateTime.UtcNow,
            },
            new ChatMessage
            {
                Id = 2,
                UserId = "8eb52ad0-6358-4bba-b6f8-b655302aa4fd",
                ChatId = 1,
                Message = "Waaa echt??? omgg nu moeten we de chat opvullen voor een scrollbar!",
                CreatedAt = DateTime.UtcNow,
            },
            new ChatMessage
            {
                Id = 3,
                UserId = "8eb52ad0-6358-4bba-b6f8-b655302aa4fd",
                ChatId = 1,
                Message = "Hallo??? :o",
                CreatedAt = DateTime.UtcNow,
            },
            new ChatMessage
            {
                Id = 4,
                UserId = "3dede8f3-0bf4-42af-83fa-f3a52f42b70f",
                ChatId = 1,
                Message = "Sorry voor de late reactie, of was dit ook een test?",
                CreatedAt = DateTime.UtcNow,
            },
            new ChatMessage
            {
                Id = 5,
                UserId = "8eb52ad0-6358-4bba-b6f8-b655302aa4fd",
                ChatId = 1,
                Message = "Ohhh, I see I see :o waaaaaaaaaaaaaaaaaaaaa",
                CreatedAt = DateTime.UtcNow,
            }
        );
    }
}
