using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Domain.Core;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Commands
{
    public class AddOrderItemCommandHandler
            : IRequestHandler<AddOrderItemCommand, AddOrderItemCommandResponse>
    {
        private readonly IRepository<PizzaOrder> _pizzaOrderRepository;
        private readonly IRepository<Pizza> _pizzaRepository;

        public AddOrderItemCommandHandler(
            IRepository<PizzaOrder> pizzaOrderRepository,
            IRepository<Pizza> pizzaRepository)
        {
            _pizzaOrderRepository = pizzaOrderRepository ?? throw new ArgumentNullException(nameof(pizzaOrderRepository));
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
        }

        public async Task<AddOrderItemCommandResponse> Handle(AddOrderItemCommand message, CancellationToken cancellationToken)
        {
            var order = await _pizzaOrderRepository.GetByIdAsync(message.PizzaOrderId);
            var pizza = await _pizzaRepository.GetByIdAsync(message.PizzaId);

            if (order == null)
                throw new Exception("Incorrect order Id.");

            if (pizza == null)
                throw new Exception("Incorrect pizza Id.");

            order.AddItem(message.PizzaId, message.NumberOfItems, message.DoughType, message.Comments);

            await _pizzaOrderRepository.SaveChangesAsync();

            return new AddOrderItemCommandResponse
            {
                AddedAt = DateTime.UtcNow,
                PizzaId = pizza.Id,
                PizzaName = pizza.Name,
                PizzaOrderId = order.Id,
                DoughType = message.DoughType,
                NumberOfItems = message.NumberOfItems,
                Comments = message.Comments
            };
        }
    }
}
