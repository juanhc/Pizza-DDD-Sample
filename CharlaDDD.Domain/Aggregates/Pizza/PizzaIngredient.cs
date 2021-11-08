using CharlaDDD.Domain.Exceptions;
using CharlaDDD.Domain.Core;

namespace CharlaDDD.Domain.Aggregates.Pizza
{
    public class PizzaIngredient : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public PizzaIngredient(string name) =>
            Name = !string.IsNullOrWhiteSpace(name)
            ? name
            : throw new PizzaValidationException($"{this.GetType().Name}.{nameof(name)}", $"{this.GetType().Name}.{nameof(name)} is mandatory.");
    }
}
