using intratest.Server.models;
using Microsoft.EntityFrameworkCore;

namespace intratest.Server
{
    public class AppContext : DbContext
    {
        public DbSet<Drink> Drinks { get; set; } = null!;
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().HasData(
                    new Drink { Id = 1, Name = "Кола", Cost = 150, Quantity = 5, Path = "./drinks/1.png" },
                    new Drink { Id = 2, Name = "Спрайт", Cost = 100, Quantity = 7, Path = "./drinks/2.png" },
                    new Drink { Id = 3, Name = "Фанта", Cost = 130, Quantity = 0, Path = "./drinks/3.png" },
                    new Drink { Id = 4, Name = "Милкис", Cost = 60, Quantity = 7, Path = "./drinks/4.png" },
                    new Drink { Id = 5, Name = "Квас", Cost = 110, Quantity = 20, Path = "./drinks/5.png" },
                    new Drink { Id = 6, Name = "Яблочный сок", Cost = 200, Quantity = 1, Path = "./drinks/6.png" }
            );
        }
    }
}
