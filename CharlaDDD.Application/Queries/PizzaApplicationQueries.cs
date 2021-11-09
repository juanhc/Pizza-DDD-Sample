using CharlaDDD.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CharlaDDD.Application.Queries
{
    public class PizzaApplicationQueries : IPizzaApplicationQueries
    {
        private readonly PizzaApplicationDbContext _context;
        private readonly IPizzaApplicationMapper _mapper;

        public PizzaApplicationQueries(PizzaApplicationDbContext context, IPizzaApplicationMapper mapper)
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
                select o.Id as OrderId, o.CreatedAt, o.Total, o.Receiver_Name, o.Receiver_LastName, o.Receiver_PhoneNumber, 
                p.Name as PizzaName, i.Id as OrderItemId, i.DoughType, i.DoughTypeName, i.NumberOfItems, i.Comments
                from PizzaOrders as o
                left join PizzaOrderItem as i
                on o.Id = i.PizzaOrderId
                inner join Pizzas p
                on i.PizzaId = p.Id
                order by o.Id";

                using(var reader = await command.ExecuteReaderAsync())
                {
                    return _mapper.MapListOfPizzaOrderFromDataReader(reader);
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
                select o.Id as OrderId, o.CreatedAt, o.Total, o.Receiver_Name, o.Receiver_LastName, o.Receiver_PhoneNumber, 
                p.Name as PizzaName, i.Id as OrderItemId, i.DoughType, i.DoughTypeName, i.NumberOfItems, i.Comments
                from PizzaOrders as o
                left join PizzaOrderItem as i
                on o.Id = i.PizzaOrderId
                inner join Pizzas p
                on i.PizzaId = p.Id
                where o.Id = @orderId
                order by o.Id";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@orderId";
                parameter.Value = orderId;

                command.Parameters.Add(parameter);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                        return _mapper.MapPizzaOrderFromDataReader(reader);
                    else
                        return null;
                }
            }
        }

        public async Task<IEnumerable<PizzaDto>> GetPizzasAsync()
        {
            var connection = _context.Database.GetDbConnection();

            using (var command = connection.CreateCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                command.CommandText = @"
                SELECT p.Id as PizzaId
                ,p.Name as PizzaName
                ,p.BasePrice,
	            i.Name as IngredientName
                FROM Pizzas p
                inner join PizzaIngredient i
                on i.PizzaId = p.Id
                order by p.Id";

                using (var reader = await command.ExecuteReaderAsync())
                {
                    return _mapper.MapListOfPizzaFromDataReader(reader);
                }
            }
        }

        public async Task<PizzaDto> GetPizzaByIdAsync(int pizzaId)
        {
            var connection = _context.Database.GetDbConnection();

            using (var command = connection.CreateCommand())
            {
                if (connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();

                command.CommandText = @"
                SELECT p.Id as PizzaId
                ,p.Name as PizzaName
                ,p.BasePrice,
	            i.Name as IngredientName
                FROM Pizzas p
                inner join PizzaIngredient i
                on i.PizzaId = p.Id
                where p.Id = @pizzaId
                order by p.Id";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@pizzaId";
                parameter.Value = pizzaId;

                command.Parameters.Add(parameter);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                        return _mapper.MapPizzaFromDataReader(reader);
                    else
                        return null;
                }
            }
        }
    }
}
