using MediatR;
using System;
using System.Collections.Generic;

namespace CharlaDDD.Application.Commands
{
    public class CreatePizzaCommand : IRequest<CreatePizzaCommandResponse>
    {
        private readonly DateTime Date;
        public DateTime GetDate() => Date;
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public IEnumerable<string> Ingredients { get; set; }

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
