using Microsoft.AspNetCore.Identity;
using MyCRM.Models;
using System.Collections;

namespace MyCRM.ViewModels
{
    public class EditUserRolesViewModel
    {
        public IEnumerable<(string,IEnumerable<IdentityRole>)>? AllRoles { get; set; }
        public CRMUser? User { get; set; }
        public IEnumerable<string>? UserRoles { get; set; }
    }
}
