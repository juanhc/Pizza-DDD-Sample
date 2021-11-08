using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Aggregates.PizzaOrder;
using CharlaDDD.Domain.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CharlaDDD.Domain.DomainServices
{
    public class PizzaOrderDomainService
    {
        private readonly IRepository<Pizza> pizzaRepository;

        public PizzaOrderDomainService(IRepository<Pizza> pizzaRepository)
            => pizzaRepository = this.pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));

        public async Task<double> GetTotalOfOrder(PizzaOrder order)
        {
            double result = default(double);

            foreach (var item in order.Items)
            {
                var pizza = await pizzaRepository.GetByIdAsync(item.PizzaId);

                var price = pizza.GetPrice(item.DoughType);

                result += price;
            }

            return result;
        }
    }
}
