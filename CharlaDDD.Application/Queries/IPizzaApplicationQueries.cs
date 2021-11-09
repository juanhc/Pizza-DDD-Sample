using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Queries
{
    public interface IPizzaApplicationQueries
    {
        Task<IEnumerable<PizzaOrderDto>> GetOrdersAsync();
        Task<PizzaOrderDto> GetOrderByIdAsync(int orderId);
        Task<IEnumerable<PizzaDto>> GetPizzasAsync();
        Task<PizzaDto> GetPizzaByIdAsync(int pizzaId);
    }
}
