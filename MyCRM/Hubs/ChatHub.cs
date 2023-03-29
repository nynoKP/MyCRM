using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using MyCRM.Models;

namespace MyCRM.Hubs
{
    public class ChatHub : Hub
    {
        readonly UserManager<CRMUser> manager;
        public ChatHub(UserManager<CRMUser> _manager) => manager = _manager;

        public async Task SendMessage(string senderId, string recipientId, string message)
        {
            
            var userName = manager.FindByIdAsync(recipientId).Result?.Id;
            var created = DateTime.Now.ToShortTimeString() + ", " + DateTime.Now.ToShortDateString();
            await Clients.User(userName ?? "").SendAsync("ReceiveMessage", senderId, recipientId, message, created);
        }
    }
}