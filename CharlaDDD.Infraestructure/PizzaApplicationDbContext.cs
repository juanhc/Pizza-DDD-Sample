using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CharlaDDD.Infrastructure
{
    public class PizzaApplicationDbContext : DbContext
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public PizzaApplicationDbContext(DbContextOptions<PizzaApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PizzaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaOrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PizzaOrderEntityConfiguration());
        }
    }
}
