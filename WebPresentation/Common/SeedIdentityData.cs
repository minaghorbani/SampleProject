using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPresentation.Common
{
    public class SeedIdentityData
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public SeedIdentityData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task Init()
        {
            await SeedRoles();
            await SeedUsers();
        }
        private async Task SeedRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Support"));
            await _roleManager.CreateAsync(new IdentityRole("User"));
            await _roleManager.CreateAsync(new IdentityRole("Author"));
        }
        private async Task SeedUsers()
        {
            var user = await _userManager.FindByNameAsync("mina.gh.66@gmail.com");
            if (user == null)
            {
                var adminUser = new ApplicationUser
                {
                    Email = "mina.gh.66@gmail.com",
                    UserName = "mina.gh.66@gmail.com",

                };

                await _userManager.CreateAsync(adminUser, "Dapa@123456");
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
