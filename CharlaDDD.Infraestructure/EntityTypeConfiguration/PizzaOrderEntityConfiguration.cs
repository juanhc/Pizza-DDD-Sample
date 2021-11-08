using CharlaDDD.Domain.Aggregates.PizzaOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharlaDDD.Infrastructure.EntityTypeConfiguration
{
    class PizzaOrderEntityConfiguration : IEntityTypeConfiguration<PizzaOrder>
    {
        public void Configure(EntityTypeBuilder<PizzaOrder> builder)
        {
            // Field-only property
            builder
                .Property<DateTime>("_date")
                .HasColumnName("CreatedAt");

            // Value Object persisted as owned entity pattern
            builder
                .OwnsOne(order => order.Receiver);
        }
    }
}
