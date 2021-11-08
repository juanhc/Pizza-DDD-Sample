using MediatR;
using System;

namespace CharlaDDD.Application.Commands
{
    public class CreatePizzaOrderCommand : IRequest<CreatePizzaOrderCommandResponse>
    {
        private readonly DateTime Date;
        public DateTime GetDate() => Date;

        public CreatePizzaOrderCommand() => Date = DateTime.UtcNow;
    }

    public class CreatePizzaOrderCommandResponse
    {
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
