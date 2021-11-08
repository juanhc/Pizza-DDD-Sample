using MediatR;
using System;

namespace CharlaDDD.Application.Commands
{
    public class DeletePizzaCommand : IRequest<DeletePizzaCommandResponse>
    {
        private readonly DateTime Date;
        public DateTime GetDate() => Date;
        public int PizzaId { get; set; }
        public DeletePizzaCommand(int pizzaId)
        {
            Date = DateTime.UtcNow;
            PizzaId = pizzaId;
        }
    }

    public class DeletePizzaCommandResponse
    {
        public DateTime DeletedAt { get; set; }
    }
}
