using Microsoft.AspNetCore.Identity;
using Rentoo.Domain.Entities;
using System.Threading.Tasks;

namespace Rentoo.Infrastructure.Seed
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string firstName = "abdelrahman";
            string lastName = "Badr";
            string birthDate = "2002-01-28"; // صيغة التاريخ
            string address = "Cairo, Egypt";
            string phoneNumber = "01032324908";
            string adminEmail = "admin@rentoo.com";
            string adminUserName = "adminrentoo";
            string adminPassword = "Admin@123";
            string adminRole = "Admin";

            // 1️⃣ إنشاء الدور لو مش موجود
            if (!await roleManager.RoleExistsAsync(adminRole))
                await roleManager.CreateAsync(new IdentityRole(adminRole));

            // 2️⃣ إنشاء المستخدم لو مش موجود
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = DateOnly.Parse(birthDate),
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Email = adminEmail,
                    UserName = adminUserName,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}
