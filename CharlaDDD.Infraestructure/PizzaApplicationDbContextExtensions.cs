using CharlaDDD.Domain.Aggregates.Pizza;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CharlaDDD.Infrastructure
{
    public static class PizzaApplicationDbContextExtensions
    {
        public static PizzaApplicationDbContext SeedData(this PizzaApplicationDbContext context)
        {
            if (context.Pizzas.Count() > 0)
                return context;

            var margarita = new Pizza("Margarita", 8);
            margarita.AddIngredientList(new List<string> { "Tomate", "Mozarella" });

            var carbonara = new Pizza("Carbonara", 8.75);
            carbonara.AddIngredientList(new List<string> { "Crema fresca", "Mozarella", "Queso", "Bacon", "Champiñon", "Cebolla" });

            var prosciutto = new Pizza("Prosciutto e funghi", 8.50);
            prosciutto.AddIngredientList(new List<string> { "Tomate", "Mozarella", "Jamón cocido", "Champiñon" });

            var quattrostagioni = new Pizza("Quattro Stagioni", 10);
            quattrostagioni.AddIngredientList(new List<string> { "Tomate", "Mozarella", "Jamón cocido", "Champiñon", "Alcachofas", "Aceitunas negras" });

            var quattroformaggi = new Pizza("Quattro Formaggi", 9.25);
            quattroformaggi.AddIngredientList(new List<string> { "Tomate", "Mozarella", "Provolone", "Parmigiano", "Gorgonzola"});

            var pizzas = new List<Pizza> { margarita, carbonara, prosciutto, quattrostagioni, quattroformaggi };

            context.Pizzas.AddRange(pizzas);

            context.SaveChanges();

            return context;
        }
    }
}
