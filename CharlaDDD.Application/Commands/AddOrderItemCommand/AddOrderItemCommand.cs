using MediatR;
using System;

namespace CharlaDDD.Application.Commands
{
    public class AddOrderItemCommand : IRequest<AddOrderItemCommandResponse>
    {
        private readonly DateTime Date;
        public DateTime GetDate() => Date;
        public int PizzaOrderId { get; set; }
        public int PizzaId { get; set; }
        public int DoughType { get; set; }
        public int NumberOfItems { get; set; }
        public string Comments { get; set; }
        public AddOrderItemCommand() => Date = DateTime.UtcNow;
    }

    public class AddOrderItemCommandResponse
    {
        public int PizzaOrderId { get; set; }
        public int PizzaOrderItemId { get; set; }
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int DoughType { get; set; }
        public int NumberOfItems { get; set; }
        public string Comments { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
