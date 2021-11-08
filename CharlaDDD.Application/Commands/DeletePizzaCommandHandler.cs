using CharlaDDD.Application.Commands;
using CharlaDDD.Domain.Aggregates.Pizza;
using CharlaDDD.Domain.Core;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CharlDeleteD.Application.Commands
{
    public class DeletePizzaCommandHandler
            : IRequestHandler<DeletePizzaCommand, DeletePizzaCommandResponse>
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public DeletePizzaCommandHandler(
            IRepository<Pizza> pizzaRepository)
            => _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));

        public async Task<DeletePizzaCommandResponse> Handle(DeletePizzaCommand message, CancellationToken cancellationToken)
        {
            var pizza = await _pizzaRepository.GetByIdAsync(message.PizzaId);

            if (pizza == null)
                throw new Exception("Incorrect pizza Id.");

            _pizzaRepository.Delete(pizza);
            await _pizzaRepository.SaveChangesAsync();

            return new DeletePizzaCommandResponse
            {
                DeletedAt = DateTime.UtcNow,
            };
        }
    }
}
