using ChatApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;

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
            //find a way to connect to group in backend instead of frontend
            return Groups.AddToGroupAsync(Context.ConnectionId, GroupId);
        }
        //Send message in group!
        public async Task SendMessage(string message, string Groupname)
        {
            //if user = null, get user from identity (how? I don't know yet)
            var user = _userManager.GetUserName(_httpContext.User);
            var time = DateTime.Now;
            await Clients.OthersInGroup(Groupname).SendAsync("ReceiveMessage", message, time, user);
            await Clients.Caller.SendAsync("ReceiveMessage", message, time, null); ;
        }

        //disconnect from group
        public Task Disconnect(string Groupname)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, Groupname);
        }
    }
}
