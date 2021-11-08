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
        private readonly ILogger<CreatePizzaOrderCommandHandler> _logger;

        public CreatePizzaOrderCommandHandler(
            IRepository<PizzaOrder> pizzaOrderRepository,
            ILogger<CreatePizzaOrderCommandHandler> logger)
        {
            _pizzaOrderRepository = pizzaOrderRepository ?? throw new ArgumentNullException(nameof(pizzaOrderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

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
