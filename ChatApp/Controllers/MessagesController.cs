using ChatApp.Areas.Identity.Data;
using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: api/Messages/{url}
        [HttpGet("{url}")]
        public async Task<IActionResult> GetMessages(string url)
        {
            var chat = _context.Chats.FirstOrDefault(c => c.Url == url);
            if (chat == null)
            {
                return NotFound();
            }

            //select the username of the first message
            var messages = await _context.ChatMessages
                .Include(m => m.ApplicationUser)
                .Where(m => m.ChatId == chat.Id)
                .Select(m => new MessageViewModel
                {
                    Message = m.Message,
                    CreatedAt = m.CreatedAt,
                    Username = m.ApplicationUser.UserName
                })
                .ToListAsync();

            return Ok(messages);
        }
    }
}
