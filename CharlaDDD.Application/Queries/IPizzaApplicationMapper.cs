using System.Collections.Generic;
using System.Data;

namespace CharlaDDD.Application.Queries
{
    public interface IPizzaApplicationMapper
    {
        PizzaOrderDto MapPizzaOrderFromDataReader(IDataReader reader);
        IEnumerable<PizzaOrderDto> MapListOfPizzaOrderFromDataReader(IDataReader reader);
        PizzaDto MapPizzaFromDataReader(IDataReader reader);
        IEnumerable<PizzaDto> MapListOfPizzaFromDataReader(IDataReader reader);
    }
}
