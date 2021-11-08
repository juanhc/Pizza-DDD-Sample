using MediatR;
using System;

namespace CharlaDDD.Application.Commands
{
    public class DeleteOrderItemCommand : IRequest<DeleteOrderItemCommandResponse>
    {
        private readonly DateTime Date;
        public DateTime GetDate() => Date;
        public int PizzaOrderId { get; set; }
        public int PizzaOrderItemId { get; set; }
        public DeleteOrderItemCommand() => Date = DateTime.UtcNow;
    }

    public class DeleteOrderItemCommandResponse
    {
        public DateTime DeletedAt { get; set; }
    }
}
