using HebrewSchool.Models;
using HebrewSchool.Models.Init;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// ���������� ���� ������ � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationDbContext>();

// ���������� �������� �������������� � �����������
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // ����� ���������� ������������
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    // ���������� ��������� �������
    options.Lockout.MaxFailedAccessAttempts = 5;
    // ���������� ����� �������������
    options.Lockout.AllowedForNewUsers = true;

    // ������ ������� �����
    options.Password.RequireDigit = false;
    // � ������ ��������� ������ ������� ��������
    options.Password.RequireLowercase = false;
    // � ������ ��������� ������, �������� �� ��������-���������.
    options.Password.RequireNonAlphanumeric = false;
    // � ������ ��������� ������ �������� ��������
    options.Password.RequireUppercase = false;
    // ����������� ����� ������
    options.Password.RequiredLength = 5;
    // ����� ���������� �������� � ������
    options.Password.RequiredUniqueChars = 1;

    // ��� ����� ��������� ������������ �� Email
    options.SignIn.RequireConfirmedEmail = false;
    // ��� ����� ��������� ������������ ������ ��������
    options.SignIn.RequireConfirmedPhoneNumber = false;

    // ���������� ������� � ����� ������������
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    // ��� ������������ ��������� ���������� Email
    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<ApplicationDbContext>();

// ���������� ������� MVC
builder.Services.AddControllersWithViews(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

/* ������ ������������� ���� ������ ���������� ���������� */
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