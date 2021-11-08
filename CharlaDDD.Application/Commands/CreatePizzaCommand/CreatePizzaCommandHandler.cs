using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Commands
{
    public class CreatePizzaCommandHandler
            : IRequestHandler<CreatePizzaCommand, CreatePizzaCommandResponse>
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public CreatePizzaCommandHandler(
            IRepository<Pizza> pizzaRepository)
            => _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));

        public async Task<CreatePizzaCommandResponse> Handle(CreatePizzaCommand message, CancellationToken cancellationToken)
        {
            var pizza = new Pizza(message.Name, message.BasePrice);

            await _pizzaRepository.AddAsync(pizza);

            await _pizzaRepository.SaveChangesAsync();

            return new CreatePizzaCommandResponse
            {
                PizzaId = pizza.Id,
                CreatedAt = DateTime.UtcNow,
                Name = message.Name,
                BasePrice = message.BasePrice
            };
        }
    }
}
