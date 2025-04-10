using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext //every class we have here must implement this root class in EF.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //making this constructor and passing the options value 
        {                                                                                           //to base class. We are doing this to pass conn. string
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                    new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2},
                    new Category { Id = 3, Name = "Horror", DisplayOrder = 3}
                );

            
        }
    }
}
