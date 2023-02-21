using Microsoft.AspNetCore.Identity;

namespace MyCRM.Models
{
    public class CRMUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
    }
}
