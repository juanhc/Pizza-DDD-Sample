using CharlaDDD.Domain.Enums;
using CharlaDDD.Domain.Exceptions;
using CharlaDDD.Domain.Core;
using System;
using System.Collections.Generic;

namespace CharlaDDD.Domain.Aggregates.Pizza
{
    public class Pizza : Entity, IAggregateRoot
    {
        private readonly double _basePrice;
        public string Name { get; private set; }

        private readonly List<PizzaIngredient> _ingredients;
        public IReadOnlyCollection<PizzaIngredient> Ingredients => _ingredients;

        public Pizza(string name, double basePrice)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new PizzaValidationException(nameof(name), $"{nameof(name)} is mandatory") : name;

            _basePrice = 
                basePrice > 0 && basePrice < 20
                ? basePrice
                : throw new PizzaValidationException(nameof(basePrice), $"{nameof(basePrice)} must be between 1 and 19");

            _ingredients = new List<PizzaIngredient>();
        }

        private Pizza() { }

        public void AddIngredient(string ingredientName) => _ingredients.Add(new PizzaIngredient(ingredientName));

        public double GetPrice(PizzaDoughType pizzaDoughType) =>
            pizzaDoughType switch
            {
                PizzaDoughType.Thin => _basePrice * 1,
                PizzaDoughType.Normal => _basePrice * 1.1,
                PizzaDoughType.Chesse => _basePrice *1.15,
                _ => throw new ArgumentOutOfRangeException(nameof(pizzaDoughType), "Not a valid value.")
            };
    }
}
