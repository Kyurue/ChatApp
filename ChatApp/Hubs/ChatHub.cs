using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        //Add user to group 
        public Task Join(string GroupId)
        {
            //find a way to connect to group in backend instead of frontend
            return Groups.AddToGroupAsync(Context.ConnectionId, GroupId);
        }
        //Send message in group!
        public async Task SendMessage(string message, string Groupname, string? user)
        {
            //if user = null, get user from identity (how? I don't know yet)
            if (user == null) user = Environment.UserName;
            await Clients.OthersInGroup(Groupname).SendAsync("ReceiveMessage", user, message, false);
            await Clients.Caller.SendAsync("ReceiveMessage", user, message, true); ;
        }

        //disconnect from group
        public Task Disconnect(string Groupname)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, Groupname);
        }
    }
}
