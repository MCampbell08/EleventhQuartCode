using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactoryDesignPattern
{
    public class PizzaStore
    {
        private PizzaFactory pizzaFactory = new PizzaFactory();
        public Pizza Order(string type)
        {
            //create(instantiate)
            Pizza p = pizzaFactory.CreatePizza(type);
            
            p.Bake();
            p.Box();
            p.Cut();

            return p;
        }
    }
}
