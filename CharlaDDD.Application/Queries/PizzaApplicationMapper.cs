using CharlaDDD.Application.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CharlaDDD.Application.Queries
{
    public class PizzaApplicationMapper : IPizzaApplicationMapper
    {
        public PizzaOrderDto MapPizzaOrderFromDataReader(IDataReader reader)
        {
            PizzaOrderDto orderDto = default;

            while (reader.Read())
            {
                if(orderDto == null)
                    orderDto = reader.ConvertToObject<PizzaOrderDto>();

                var itemDto = reader.ConvertToObject<PizzaOrderItemDto>();
                orderDto.Items.Add(itemDto);
            }

            return orderDto;
        }

        public IEnumerable<PizzaOrderDto> MapListOfPizzaOrderFromDataReader(IDataReader reader)
        {
            IList<PizzaOrderDto> orderDtoList = new List<PizzaOrderDto>();
            PizzaOrderDto orderDto = new PizzaOrderDto();

            while (reader.Read())
            {
                var currentOrderId = (int)reader["OrderId"];

                var existingOrder = orderDtoList.FirstOrDefault(x => x.OrderId == currentOrderId);

                if (existingOrder == null)
                {
                    orderDto = reader.ConvertToObject<PizzaOrderDto>();

                    orderDtoList.Add(orderDto);
                }
                else
                    orderDto = existingOrder;

                var orderItemDto = reader.ConvertToObject<PizzaOrderItemDto>();

                orderDto.Items.Add(orderItemDto);
            }

            return orderDtoList;
        }

        public PizzaDto MapPizzaFromDataReader(IDataReader reader)
        {
            PizzaDto pizzaDto = default;

            while (reader.Read())
            {
                if (pizzaDto == null)
                    pizzaDto = reader.ConvertToObject<PizzaDto>();

                if (reader["IngredientName"] != null)
                    pizzaDto.Ingredients.Add((string)reader["IngredientName"]);
            }

            return pizzaDto;
        }

        public IEnumerable<PizzaDto> MapListOfPizzaFromDataReader(IDataReader reader)
        {
            IList<PizzaDto> pizzaDtoList = new List<PizzaDto>();
            PizzaDto pizzaDto = new PizzaDto();

            while (reader.Read())
            {
                var currentPizzaId = (int)reader["PizzaId"];

                var existingPizza = pizzaDtoList.FirstOrDefault(x => x.PizzaId == currentPizzaId);

                if (existingPizza == null)
                {
                    pizzaDto = reader.ConvertToObject<PizzaDto>();

                    pizzaDtoList.Add(pizzaDto);
                }
                else
                    pizzaDto = existingPizza;

                if(reader["IngredientName"] != null)
                    pizzaDto.Ingredients.Add((string)reader["IngredientName"]);
            }

            return pizzaDtoList;
        }
    }
}
