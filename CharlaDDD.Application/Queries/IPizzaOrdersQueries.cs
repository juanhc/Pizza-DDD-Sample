using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Queries
{
    public interface IPizzaOrdersQueries
    {
        Task<IEnumerable<PizzaOrderDto>> GetOrdersAsync();
        Task<PizzaOrderDto> GetOrderByIdAsync(int orderId);
    }
}
