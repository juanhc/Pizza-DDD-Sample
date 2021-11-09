using System;
using System.Collections.Generic;

namespace CharlaDDD.Application.Queries
{
    public class PizzaDto
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public double BasePrice { get; set; }
        public ICollection<string> Ingredients { get; set; }
        public PizzaDto() => Ingredients = new List<string>();
    }
}
