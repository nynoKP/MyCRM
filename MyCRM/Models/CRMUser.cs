using Microsoft.AspNetCore.Identity;

namespace MyCRM.Models
{
    public class CRMUser : IdentityUser
    {
        private string? avatarPath { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }

        public string? AvatarPath
        { 
            get 
            {
                if (string.IsNullOrWhiteSpace(avatarPath))
                {
                    return "dist/img/avatar5.png";
                }
                return avatarPath;
            }
            set 
            { 
                avatarPath = value;
            } 
        }

        public string GetShortName()
        {
            var fn = string.IsNullOrWhiteSpace(FirstName) ? string.Empty : FirstName.Trim();
            var ln = string.IsNullOrWhiteSpace(LastName) ? string.Empty : LastName.Trim()[0].ToString() + ". ";
            return ln + fn;
        }

    }
}
