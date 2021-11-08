using CharlaDDD.Domain.Enums;
using CharlaDDD.Domain.Exceptions;
using CharlaDDD.Domain.Core;
using System;

namespace CharlaDDD.Domain.Aggregates.PizzaOrder
{
    public class PizzaOrderItem : Entity
    {
        public int PizzaId { get; private set; }
        public PizzaDoughType DoughType { get; private set; }
        public string DoughTypeName { get; private set; }
        public int Number { get; private set; }
        public string Comments { get; private set; }

        public PizzaOrderItem(int pizzaId, int numberOfItems, int doughType, string comments)
        {
            PizzaId = pizzaId;

            Number =
                numberOfItems > 0 && numberOfItems < 50
                ? numberOfItems
                : throw new PizzaOrderItemValidationException(nameof(numberOfItems), $"{nameof(numberOfItems)} must be between 1 and 49.");

            DoughType = Enum.IsDefined(typeof(PizzaDoughType), doughType) 
                ? (PizzaDoughType)doughType 
                : throw new PizzaOrderItemValidationException(nameof(DoughType), "Incorrect Dough Type");

            DoughTypeName = ((PizzaDoughType)doughType).ToString();

            Comments = comments;
        }

        private PizzaOrderItem() { }
    }
}
