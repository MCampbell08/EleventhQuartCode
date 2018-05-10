using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactoryDesignPattern
{
    public abstract class PizzaStore
    {
        private PizzaFactory pizzaFactory = new PizzaFactory();
        public Pizza Order(string type)
        {
            //create(instantiate)
            Pizza p = CreatePizza(type);
            
            p.Bake();
            p.Box();
            p.Cut();

            return p;
        }
        public abstract Pizza CreatePizza(string type);
    }
}
