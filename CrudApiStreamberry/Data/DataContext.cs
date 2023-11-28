using CrudApiStreamberry.Controllers;
using CrudApiStreamberry.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiStreamberry.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }

    }
}
