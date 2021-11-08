using System;
using System.Collections.Generic;

namespace CharlaDDD.Application.Queries
{
    public class PizzaOrderDto
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Receiver_Name { get; set; }
        public string Receiver_LastName { get; set; }
        public string Receiver_PhoneNumber { get; set; }
        public double Total { get; set; }
        public ICollection<PizzaOrderItemDto> Items { get; set; }
        public PizzaOrderDto() => Items = new List<PizzaOrderItemDto>();
    }

    public class PizzaOrderItemDto
    {
        public string PizzaName { get; set; }
        public string DoughTypeName { get; set; }
        public int NumberOfItems { get; set; }
        public string Comments { get; set; }
    }
}
