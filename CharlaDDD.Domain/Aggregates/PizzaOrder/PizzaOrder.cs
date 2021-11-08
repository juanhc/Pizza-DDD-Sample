using CharlaDDD.Domain.Enums;
using CharlaDDD.Domain.Exceptions;
using CharlaDDD.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CharlaDDD.Domain.Aggregates.PizzaOrder
{
    public class PizzaOrder : Entity, IAggregateRoot
    {
        private readonly DateTime _date;
        private readonly List<PizzaOrderItem> _items;
        public IReadOnlyCollection<PizzaOrderItem> Items => _items;
        public Receiver Receiver { get; private set; }
        public double Total { get; private set; }

        public PizzaOrder()
        {
            _date = DateTime.UtcNow;
            _items = new List<PizzaOrderItem>();
        }

        public void AddReceiver(string name, string lastName, string phoneNumber)
            => Receiver = new Receiver(name, lastName, phoneNumber);

        public void AddItem(int pizzaId, int numberOfItems, int doughType, string comments) 
            => _items.Add(new PizzaOrderItem(pizzaId, numberOfItems, doughType, comments));

        public void DeleteItem(int itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);

            if (item == null)
                throw new PizzaOrderItemNotFoundException();

            _items.Remove(item);
        }

        public void UpdateTotal(double total) => Total = total;
    }
}
