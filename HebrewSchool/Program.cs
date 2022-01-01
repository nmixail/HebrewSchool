using HebrewSchool.Models;
using HebrewSchool.Models.Init;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Добавление базы данных в качестве сервиса в приложение
builder.Services.AddDbContext<ApplicationDbContext>();

// Добавление сервисов аутентификации и авторизации
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // время блокировки пользователя
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // количество неудачных попыток
    options.Lockout.MaxFailedAccessAttempts = 5;
    // блокировка новых пользователей
    options.Lockout.AllowedForNewUsers = true;

    // Пароль требует цифры
    options.Password.RequireDigit = false;
    // В пароле требуется символ нижнего регистра
    options.Password.RequireLowercase = false;
    // В пароле требуется символ, отличный от буквенно-цифрового.
    options.Password.RequireNonAlphanumeric = false;
    // В пароле требуется символ верхнего регистра
    options.Password.RequireUppercase = false;
    // минимальная длина пароля
    options.Password.RequiredLength = 5;
    // число уникальных символов в пароле
    options.Password.RequiredUniqueChars = 1;

    // для входа требуется потверждение по Email
    options.SignIn.RequireConfirmedEmail = false;
    // для входа требуется потверждение номера телефона
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // допустимые символы в имени пользователя
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    // для пользователя требуется уникальный Email
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Добавление методов MVC
builder.Services.AddControllersWithViews(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

/* Запуск инициализации базы данных начальными значениями */
await Initializer.Run(app);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();