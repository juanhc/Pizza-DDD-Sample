using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CharlaDDD.Infrastructure
{
    public class PizzaOrdersDbContext : DbContext
    {
        public DbSet<PizzaOrder> PizzaOrders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public PizzaOrdersDbContext(DbContextOptions<PizzaOrdersDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Pizza>(new PizzaEntityConfiguration());
            modelBuilder.ApplyConfiguration<PizzaOrderItem>(new PizzaOrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration<PizzaOrder>(new PizzaOrderEntityConfiguration());
        }
    }
}
