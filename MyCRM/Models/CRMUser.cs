using Microsoft.AspNetCore.Identity;

namespace MyCRM.Models
{
    public class CRMUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }

        public string GetShortName()
        {
            var fn = string.IsNullOrWhiteSpace(FirstName) ? string.Empty : FirstName.Trim();
            var ln = string.IsNullOrWhiteSpace(LastName) ? string.Empty : LastName.Trim()[0].ToString() + ". ";
            return ln + fn;
        }
    }
}
