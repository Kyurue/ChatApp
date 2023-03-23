using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace ChatApp.Hubs
{
    public class ChatList : Hub
    {
        public Task Join(string GroupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, GroupName);
        }
    }
}
