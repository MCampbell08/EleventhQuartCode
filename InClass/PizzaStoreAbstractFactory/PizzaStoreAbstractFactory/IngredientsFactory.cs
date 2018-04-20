using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStoreAbstractFactory
{
    public abstract class IngredientsFactory
    {
        public abstract Cheese CreateCheese();
        public abstract Sauce CreateSauce();
        public abstract Crust CreateCrust();
        public abstract List<Toppings> CreateToppings();
    }
}
