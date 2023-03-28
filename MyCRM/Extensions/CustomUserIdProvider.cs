using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using MyCRM.Models;

namespace MyCRM.Extensions
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        private readonly UserManager<CRMUser> _userManager;
        public CustomUserIdProvider(UserManager<CRMUser> userManager) => _userManager = userManager;
        
        public string? GetUserId(HubConnectionContext connection)
        {
            var userId = _userManager.FindByNameAsync(connection.User.Identity.Name)?.Result?.Id;
            return userId;
        }
    }
}
