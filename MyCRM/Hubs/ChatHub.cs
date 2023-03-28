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
            var userName = manager.FindByIdAsync(recipientId).Result?.UserName;
            //await Clients.All.SendAsync("ReceiveMessage", senderId, recipientId, message);
            await Clients.User(userName ?? "").SendAsync("ReceiveMessage", senderId, recipientId, message);
        }
    }
}