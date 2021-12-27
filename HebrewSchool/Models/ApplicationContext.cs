using HebrewSchool.Models.Account;
using HebrewSchool.Models.School;
using Microsoft.EntityFrameworkCore;

namespace HebrewSchool.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Name> Names { get; set; } = null!;
        public DbSet<Surname> Surnames { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
        public DbSet<Year> Years { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // строка подключения быза данных
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HebrewSchooldb;Username=postgres;Password=ytkmpz09121992");
        }
    }
}
