using CharlaDDD.Application.Commands;
using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Domain.Core;
using CharlaDDD.Domain.DomainServices;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CharlDeleteD.Application.Commands
{
    public class DeleteOrderItemCommandHandler
            : IRequestHandler<DeleteOrderItemCommand, DeleteOrderItemCommandResponse>
    {
        private readonly IRepository<PizzaOrder> _pizzaOrderRepository;
        private readonly PizzaOrderDomainService _domainService;

        public DeleteOrderItemCommandHandler(
            IRepository<PizzaOrder> pizzaOrderRepository,
            PizzaOrderDomainService domainService)
        {
            _pizzaOrderRepository = pizzaOrderRepository ?? throw new ArgumentNullException(nameof(pizzaOrderRepository));
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
        }

        public async Task<DeleteOrderItemCommandResponse> Handle(DeleteOrderItemCommand message, CancellationToken cancellationToken)
        {
            var order = await _pizzaOrderRepository.GetByIdAsync(message.PizzaOrderId);

            if (order == null)
                throw new Exception("Incorrect order Id.");
           
            order.DeleteItem(message.PizzaOrderItemId);
            await _domainService.UpdateTotalOfOrder(order);

            await _pizzaOrderRepository.SaveChangesAsync();

            return new DeleteOrderItemCommandResponse
            {
                DeletedAt = DateTime.UtcNow,
            };
        }
    }
}
