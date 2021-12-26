using HebrewSchool.Models.Account;
using HebrewSchool.Models.School;
using Microsoft.EntityFrameworkCore;

namespace HebrewSchool.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Surname> Surnames { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Year> Years { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
             : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=HebrewSchooldb;Username=postgres;Password=ytkmpz09121992");
        }
    }
}
