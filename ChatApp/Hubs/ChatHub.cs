using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        //public Task Join(string GroupId)
        //{
        //    return Groups.AddToGroupAsync(Context.ConnectionId, GroupId);
        //}
        //public async Task SendMessage(string message, string Groupname, string? user)
        //{
        //    await Clients.Group(Groupname).SendAsync("ReceiveMessage", user, message);
        //}

        //public Task Disconnect(string Groupname)
        //{
        //    return Groups.RemoveFromGroupAsync(Context.ConnectionId, Groupname);
        //}
    }
}
