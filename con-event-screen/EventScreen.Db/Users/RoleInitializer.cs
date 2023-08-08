using EventScreen.Db.Data;
using EventScreen.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PasswordGenerator;
using Serilog;

namespace EventScreen.Db.Users;

public static class RoleInitializer
{
	public static async Task CreateRoles(IServiceProvider provider)
	{
		using var scope = provider.CreateScope();
		var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
		var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
		
		await using var db = ApplicationDbContext.Get();

		await EnsureRoles(roleManager);

		// find the user with the admin email 
		var user = await userManager.FindByEmailAsync("admin@email.de");

		if (user == null)
		{
			Log.Information("No Users detected. Setting up default admin account");

			var defaultAdmin = new ApplicationUser()
			{
				UserName = "admin@example.org",
				Email = "admin@example.org",
				FirstName = "admin",
				LastName = "admin",
				EmailConfirmed = true,
			};

			var pwd = new Password(8).Next();

			var created = await userManager.CreateAsync(defaultAdmin, pwd);

			if (created.Succeeded)
			{
				var createdUser = await userManager.FindByNameAsync("admin@example.org");
				Log.Debug("Created admin with {InitialAdminPassword}", pwd);
				
				await userManager.AddToRoleAsync(createdUser!, Roles.GlobalAdministrator);
				Log.Debug("Added admin user to {Role} Role", Roles.GlobalAdministrator);
				
				await userManager.AddToRoleAsync(createdUser!, Roles.Administrator);
				Log.Debug("Added admin user to {Role} Role", Roles.Administrator);
				return;
			}

            Log.Error("Failed to create Admin user {Errors}", created.Errors.First().Description);

			return;
		}

		if (!await userManager.IsInRoleAsync(user!, Roles.GlobalAdministrator))
		{
			await userManager.AddToRoleAsync(user!, Roles.GlobalAdministrator);
			Log.Debug("Added admin user to {Role} Role", Roles.GlobalAdministrator);
		}

		if (!await userManager.IsInRoleAsync(user!, Roles.Administrator))
		{
			await userManager.AddToRoleAsync(user!, Roles.Administrator);
			Log.Debug("Added admin user to {Role} Role", Roles.Administrator);
		}
	}

	private static async Task EnsureRoles(RoleManager<IdentityRole> roleManager)
	{
		foreach (var role in Roles.RoleArray)
		{
			var result = await roleManager.FindByNameAsync(role);
			if (result != null) continue;

			await roleManager.CreateAsync(new IdentityRole(role));
		}
	}
}