using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Domain.Core;
using System;
using System.Threading.Tasks;

namespace CharlaDDD.Domain.DomainServices
{
    public class PizzaOrderDomainService
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public PizzaOrderDomainService(IRepository<Pizza> pizzaRepository)
            => _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));

        public async Task UpdateTotalOfOrder(PizzaOrder order)
        {
            double result = default;

            foreach (var item in order.Items)
            {
                var pizza = await _pizzaRepository.GetByIdAsync(item.PizzaId);

                var price = pizza.GetPrice(item.DoughType);

                result += price * item.NumberOfItems;
            }

            order.UpdateTotal(result);
        }
    }
}
