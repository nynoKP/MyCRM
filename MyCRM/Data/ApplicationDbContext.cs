using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCRM.Models;

namespace MyCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext<CRMUser>
    {
        public DbSet<News> News { get; set; }
        public DbSet<CRMUser> CRMUser { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}