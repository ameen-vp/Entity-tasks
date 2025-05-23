using EntityInsoteredprocedure_allcrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityInsoteredprocedure_allcrud.AppDB

{
    public class AppdbContext : DbContext

    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {
        }
        public DbSet<Productclass> productclass { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productclass>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); 
        }
    }
    }



