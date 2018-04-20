using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreAbstractFactory
{
    public class NYPizzaIngredientsFactory : IngredientsFactory
    {
        public override Cheese CreateCheese()
        {
            return Cheese.Regular;
        }

        public override Crust CreateCrust()
        {
            return Crust.Thin;
        }

        public override Sauce CreateSauce()
        {
            return Sauce.Marinara;
        }

        public override List<Toppings> CreateToppings()
        {
            return new List<Toppings> { Toppings.Salami, Toppings.Anchovies };
        }
    }
}
