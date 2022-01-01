using Microsoft.AspNetCore.Identity;

namespace HebrewSchool.Models.Init
{
	/* Класс для записи начальных данных в базу данных */
	public class DbInitializer
	{
		private UserManager<IdentityUser> _userManager;
		private RoleManager<IdentityRole> _roleManager;
		public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
			_userManager = userManager;
			_roleManager = roleManager;
        }
		/* Добавление в базу данных первые роли */
		public async Task RoleInitializeAsync()
		{
			await CreateRole(role: "Администратор");
			await CreateRole(role: "Пользователь");
		}

		/* Добавление в базу данных первых пользователей */
		public async Task UserInitializeAsync()
		{
			await CreateUser(name: "Admin", email: "admin@gmail.com", role: "Администратор", password: "admin");
			await CreateUser(name: "Test", email: "test@gmail.com", role: "Пользователь", password: "admin");
		}

		/* Создание пользователя в базе данных*/
		private async Task CreateUser(string name, string role, string email, string password)
        {
			if (await _userManager.FindByNameAsync(name) == null)
			{
				IdentityUser user = new IdentityUser { Email = email, UserName = name };
				IdentityResult result = await _userManager.CreateAsync(user, password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, role);
				}
			}
		}
		/* Создание роли в базе данных*/
		private async Task CreateRole(string role)
        {
			if (await _roleManager.FindByNameAsync(role) == null)
			{
				await _roleManager.CreateAsync(new IdentityRole(role));
			}
		}
	}
}
