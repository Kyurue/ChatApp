using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public Task Join(string GroupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
        }
        public async Task SendMessage(string user, string message, string Groupname)
        {
            await Clients.Group(Groupname).SendAsync("ReceiveMessage", user, message);
        }

        public Task Disconnect(string Groupname)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, Groupname);
        }
    }
}
