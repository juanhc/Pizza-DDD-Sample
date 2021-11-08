using CharlaDDD.Application.Core;
using System;
using System.Collections.Generic;
using System.Data;

namespace CharlaDDD.Application.Queries
{
    public class PizzaOrderMapper : IPizzaOrderMapper
    {
        public PizzaOrderDto MapFromDataReader(IDataReader reader)
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

        public IEnumerable<PizzaOrderDto> MapListFromDataReader(IDataReader reader)
        {
            IList<PizzaOrderDto> orderDtoList = new List<PizzaOrderDto>();
            PizzaOrderDto orderDto = new PizzaOrderDto();
            int orderId = default;

            while (reader.Read())
            {
                var currentOrderId = (int)reader["OrderId"];

                if(currentOrderId != orderId)
                {
                    orderDto = reader.ConvertToObject<PizzaOrderDto>();

                    orderDtoList.Add(orderDto);
                }

                var orderItemDto = reader.ConvertToObject<PizzaOrderItemDto>();

                orderDto.Items.Add(orderItemDto);
            }

            return orderDtoList;
        }
    }
}
