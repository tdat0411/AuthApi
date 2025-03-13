using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthApi.Data
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly string AdminRoleUserName = "Admin";
        private readonly string UserRoleUserName = "User";

        public DbInitializer(AppDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            // role
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = AdminRoleUserName,
                    Name = AdminRoleUserName,
                    NormalizedName = AdminRoleUserName.ToUpper(),
                });

                await _roleManager.CreateAsync(new IdentityRole
                {
                    Id = UserRoleUserName,
                    Name = UserRoleUserName,
                    NormalizedName = UserRoleUserName.ToUpper(),
                });
            }

            // member
            if (!_userManager.Users.Any())
            {
                var resultAdmin = await _userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "admin",
                    Name = "admin",
                    Email = "admin@gmail.com",
                    LockoutEnabled = false
                }, "Admin@123");
                var resultUser = await _userManager.CreateAsync(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "user",
                    UserName = "user",
                    Email = "user@gmail.com",
                    LockoutEnabled = false
                }, "User@123");
                if (resultAdmin.Succeeded && resultUser.Succeeded)
                {
                    var admin = await _userManager.FindByNameAsync("admin");
                    var user = await _userManager.FindByNameAsync("user");
                    await _userManager.AddToRoleAsync(admin, AdminRoleUserName);
                    await _userManager.AddToRoleAsync(user, UserRoleUserName);
                }
            }
        }
    }
}