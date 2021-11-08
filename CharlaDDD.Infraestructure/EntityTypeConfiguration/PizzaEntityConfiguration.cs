using CharlaDDD.Domain.Aggregates.Pizza;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
