using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharlaDDD.Infrastructure.EntityTypeConfiguration
{
    class PizzaOrderItemEntityConfiguration : IEntityTypeConfiguration<PizzaOrderItem>
    {
        public void Configure(EntityTypeBuilder<PizzaOrderItem> builder)
        {
            builder
                 .HasOne<Pizza>()
                 .WithOne()
                 .HasForeignKey<PizzaOrderItem>(oi => oi.PizzaId);
        }
    }
}
