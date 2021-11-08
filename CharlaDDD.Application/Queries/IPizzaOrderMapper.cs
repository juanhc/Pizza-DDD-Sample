using System.Collections.Generic;
using System.Data;

namespace CharlaDDD.Application.Queries
{
    public interface IPizzaOrderMapper
    {
        PizzaOrderDto MapFromDataReader(IDataReader reader);
        IEnumerable<PizzaOrderDto> MapListFromDataReader(IDataReader reader);
    }
}
