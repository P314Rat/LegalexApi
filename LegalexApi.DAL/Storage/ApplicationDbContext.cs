using LegalexApi.DAL.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexApi.DAL.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
