using MediatR;
using System;

namespace CharlaDDD.Application.Commands
{
    public class CreatePizzaCommand : IRequest<CreatePizzaCommandResponse>
    {
        private readonly DateTime Date;
        public DateTime GetDate() => Date;
        public string Name { get; set; }
        public double BasePrice { get; set; }

        public CreatePizzaCommand() => Date = DateTime.UtcNow;
    }

    public class CreatePizzaCommandResponse
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
