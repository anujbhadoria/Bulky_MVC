using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext //every class we have here must implement this root class in EF.
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //making this constructor and passing the options value 
        {                                                                                           //to base class. We are doing this to pass conn. string
            
        }

        public DbSet<Category> Categories { get; set; }
    }
}
