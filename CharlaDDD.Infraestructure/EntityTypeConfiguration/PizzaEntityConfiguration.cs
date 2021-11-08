using CharlaDDD.Domain.Aggregates.Pizza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharlaDDD.Infrastructure.EntityTypeConfiguration
{
    class PizzaEntityConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            // Field-only property
            builder
                .Property<double>("_basePrice")
                .HasColumnName("BasePrice");

            builder
                .HasMany(p => p.Ingredients)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
