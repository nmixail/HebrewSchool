using Microsoft.AspNetCore.Identity;

namespace HebrewSchool.Models.Init
{
    /* Класс для создание базы данных с начальными значениями */
    public class Initializer
    {
        public static async Task Run(WebApplication app)
        {
            using (var scope = app.Services.CreateAsyncScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
                try
                {
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    var init = new DbInitializer(userManager, rolesManager);
                    await init.RoleInitializeAsync();
                    await init.UserInitializeAsync();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
