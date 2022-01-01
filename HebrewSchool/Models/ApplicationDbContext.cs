using HebrewSchool.Models.School;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HebrewSchool.Models
{
    /* Класс для взаимодействия базой данных */
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Name> Names { get; set; } = null!;
        public DbSet<Surname> Surnames { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Year> Years { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // строка подключения быза данных
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HebrewSchooldbtest3;Username=postgres;Password=ytkmpz09121992");
        }
    }
}
