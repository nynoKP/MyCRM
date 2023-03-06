using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCRM.Models;

namespace MyCRM.Data
{
    public class ApplicationDbContext : IdentityDbContext<CRMUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
        }

        public DbSet<News> News { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Contragent> Contragent { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskState> TaskStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AdminSeed(builder);
            TaskStatusesSeed(builder);
            base.OnModelCreating(builder);
        }

        private void TaskStatusesSeed(ModelBuilder builder)
        {
            List<TaskState> tasks = new List<TaskState>()
            {
                new TaskState
                {
                    Id = 1,
                    Name = "Неопределена"
                },
                new TaskState
                {
                    Id = 2,
                    Name = "Активна"
                },
                new TaskState
                {
                    Id = 3,
                    Name = "В ожидании"
                },
                new TaskState
                {
                    Id = 4,
                    Name = "Завершена"
                }
            };
            builder.Entity<TaskState>().HasData(tasks);
        }

        private void AdminSeed(ModelBuilder builder)
        {
            string ADMIN_ID = "c40e32c7-ba16-40be-a0ff-3a8f47e37e88";
            string ROLE_ID = "286077a1-4593-4620-b583-b5375aba3f5b";

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new CRMUser
            {
                Id = ADMIN_ID,
                Email = "admin@admin",
                NormalizedEmail = "ADMIN@ADMIN",
                EmailConfirmed = true,
                FirstName = "First",
                LastName = "Last",
                Patronymic = "Patronimic",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };

            //set user password
            PasswordHasher<CRMUser> ph = new PasswordHasher<CRMUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "password123");

            //seed user
            builder.Entity<CRMUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}