using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudBlog.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var superAdminRoleId = "2b5c8a86-e998-4769-ab75-947761d77aaf";
            var adminRoleId = "2cf34f16-981b-4dd1-b0eb-096c33eab516";
            var userRoleId = "d6f52a2c-b6b0-4618-96ab-117eb931f339";

            //Seed Roles (User, Admin, Super Admin)
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name = "SuperAdmin",
                    NormalizedName= "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName= "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName= "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Super Admin User
            var superAdminId = "400ffb69-42f7-46ee-8f96-c86110589499";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                 NormalizedEmail = "superadmin@bloggie.com".ToUpper(),

                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin123");
            builder.Entity<IdentityUser>().HasData(superAdminUser);
            //Add All Roles To Super Admin
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                 new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
