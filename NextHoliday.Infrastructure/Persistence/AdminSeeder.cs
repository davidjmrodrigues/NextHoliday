using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace NextHoliday.Infrastructure.Persistence
{
    public static class AdminSeeder
    {
        public static async Task EnsureUserIsAdminAsync(IServiceProvider services, string targetEmail)
        {
            if (string.IsNullOrWhiteSpace(targetEmail))
                throw new ArgumentException("The user email can not be empty or null.", nameof(targetEmail));

            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            const string adminRole = "Admin";

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
                Console.WriteLine($"[Identity Setup] Role '{adminRole}' created with success.");
            }

            var user = await userManager.FindByEmailAsync(targetEmail);

            if (user != null)
            {
                if (!await userManager.IsInRoleAsync(user, adminRole))
                {
                    var result = await userManager.AddToRoleAsync(user, adminRole);

                    if (result.Succeeded)
                    {
                        Console.WriteLine($"[Identity Setup] SUCCESS: Account '{targetEmail}' has been promoted to Admin!");
                    }
                    else
                    {
                        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                        Console.WriteLine($"[Identity Setup] ERROR while promoting: {errors}");
                    }
                } 
                else
                {
                    Console.WriteLine($"[Identity Setup] Account '{targetEmail}' has Admin status.");
                }
            }
            else
            {
                Console.WriteLine($"[Identity Setup] WARNING: Email '{targetEmail}' not found.");
            }
        }
    }
}
