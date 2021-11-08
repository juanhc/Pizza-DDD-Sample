using CharlaDDD.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Queries
{
    public class PizzaOrdersQueries : IPizzaOrdersQueries
    {
        private readonly PizzaOrdersDbContext _context;
        private readonly IPizzaOrderMapper _mapper;

        public PizzaOrdersQueries(PizzaOrdersDbContext context, IPizzaOrderMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PizzaOrderDto>> GetOrdersAsync()
        {
            var connection = _context.Database.GetDbConnection();

            using (var command = connection.CreateCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                command.CommandText = @"
                select o.Id as OrderId, o.CreatedAt, o.Receiver_Name, o.Receiver_LastName, o.Receiver_PhoneNumber, p.Name as PizzaName, i.DoughType, i.DoughTypeName, i.Number as NumberOfItems, i.Comments
                from PizzaOrders as o
                left join PizzaOrderItem as i
                on o.Id = i.PizzaOrderId
                inner join Pizzas p
                on i.PizzaId = p.Id";

                using(var reader = await command.ExecuteReaderAsync())
                {
                    return _mapper.MapListFromDataReader(reader);
                }
            }
        }

        public async Task<PizzaOrderDto> GetOrderByIdAsync(int orderId)
        {
            var connection = _context.Database.GetDbConnection();

            using (var command = connection.CreateCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                command.CommandText = @"
                select o.Id as OrderId, o.CreatedAt, o.Receiver_Name, o.Receiver_LastName, o.Receiver_PhoneNumber, p.Name as PizzaName, i.DoughType, i.DoughTypeName, i.Number as NumberOfItems, i.Comments
                from PizzaOrders as o
                left join PizzaOrderItem as i
                on o.Id = i.PizzaOrderId
                inner join Pizzas p
                on i.PizzaId = p.Id
                where o.Id = @orderId";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@orderId";
                parameter.Value = orderId;

                command.Parameters.Add(parameter);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                        return _mapper.MapFromDataReader(reader);
                    else
                        return null;
                }
            }
        }
    }
}
