using Microsoft.AspNetCore.Identity;
using MyCRM.Models;
using System.Reflection;

namespace MyCRM.Services
{
    public class RolesService
    {
        private UserManager<CRMUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public RolesService(UserManager<CRMUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public List<IdentityRole> GetAll()
        {
            return roleManager.Roles.ToList();
        }

        public void Sync()
        {
            var asm = Assembly.GetAssembly(typeof(Program));
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Microsoft.AspNetCore.Mvc.ControllerBase).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new {
                        Controller = x.DeclaringType.Name,
                        Action = x.Name,
                        ReturnType = x.ReturnType.Name,
                        Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", "")))
                    })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();


            foreach (var item in controlleractionlist)
            {
                var apiName = item.Action + item.Controller.Replace("Controller","");
                if(!IsRoleInBlacklist(apiName))
                {
                    roleManager.CreateAsync(new IdentityRole(apiName)).Wait();
                }
            }
        }

        private bool IsRoleInBlacklist(string roleName)
        {
            var blacklist = "SendMessageChat,GetChatChat";
            if(blacklist.Contains(roleName)) return true;
            return false;
        }
    }
}
