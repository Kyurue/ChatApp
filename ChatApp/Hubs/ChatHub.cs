using ChatApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatApp.Data;
#nullable disable
namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private static HttpContext _httpContext => new HttpContextAccessor().HttpContext;
        public ChatHub(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //Add user to group 
        public Task Join(string GroupId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, GroupId);
        }
        //Send message in group!
        public async Task SendMessage(string message, string Groupname)
        {
            var user = _userManager.GetUserName(_httpContext.User);
            if(user != null)
            {
                var userId = _userManager.GetUserId(_httpContext.User);
                var time = DateTime.Now;
                _context.ChatMessages.Add(new Data.ChatMessage
                {
                    Message = message,
                    CreatedAt = time,
                    UserId = userId,
                    ChatId = await _context.Chats.Where(x => x.Url == Groupname).Select(x => x.Id).SingleOrDefaultAsync()
                });
                await _context.SaveChangesAsync();
                await Clients.OthersInGroup(Groupname).SendAsync("ReceiveMessage", message, time, user);
                await Clients.Caller.SendAsync("ReceiveMessage", message, time, null);
            }
        }

        //disconnect from group
        public Task Disconnect(string Groupname)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, Groupname);
        }
    }
}
