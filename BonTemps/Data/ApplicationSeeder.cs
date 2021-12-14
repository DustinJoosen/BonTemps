using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Data
{
	public class ApplicationSeeder
	{
		private const string _password = "Welkom123!";
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		private readonly List<string> _roles = new List<string> { "Customer", "Employee" };


		public ApplicationSeeder(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public UserManager<IdentityUser> UserManager => _userManager;

		public async Task SeedRoles()
		{

			//loop through all roles, and add them if they do not exist
			foreach (var role in _roles)
			{
				var identityRole = new IdentityRole
				{
					Name = role
				};

				var new_role = await _roleManager.FindByNameAsync(role);
				if (new_role != null)
				{
					continue;
				}

				await _roleManager.CreateAsync(identityRole);
			}
		}

		public async Task SeedUsers()
		{
			//loop through all roles
			foreach (var role_name in _roles)
			{
				//create a new user, with the email started by their role
				var identityUser = new IdentityUser
				{
					Email = $"{role_name}@bontemps.mbo",
					EmailConfirmed = true
				};

				//check if the user exists, otherwise add them and give them their roles+medewerker
				var user = await UserManager.FindByEmailAsync(identityUser.Email);
				if (user == null)
				{
					identityUser.UserName = identityUser.Email;
					var result = await UserManager.CreateAsync(identityUser, _password);
					if (result.Succeeded)
					{
						await UserManager.AddToRoleAsync(identityUser, role_name);
					}
				}
			}

		}
	}
}
