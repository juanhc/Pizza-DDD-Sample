using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Domain.Enums;
using CharlaDDD.Domain.Core;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Commands
{
    public class CreatePizzaOrderCommandHandler
            : IRequestHandler<CreatePizzaOrderCommand, CreatePizzaOrderCommandResponse>
    {
        private readonly IRepository<PizzaOrder> _pizzaOrderRepository;

        public CreatePizzaOrderCommandHandler(
            IRepository<PizzaOrder> pizzaOrderRepository)
            => _pizzaOrderRepository = pizzaOrderRepository ?? throw new ArgumentNullException(nameof(pizzaOrderRepository));

        public async Task<CreatePizzaOrderCommandResponse> Handle(CreatePizzaOrderCommand message, CancellationToken cancellationToken)
        {
            var order = new PizzaOrder();

            await _pizzaOrderRepository.AddAsync(order);

            await _pizzaOrderRepository.SaveChangesAsync();

            return new CreatePizzaOrderCommandResponse
            {
                OrderId = order.Id,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
