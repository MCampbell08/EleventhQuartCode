using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactoryDesignPattern
{
    public class NyStylePizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza p = new Pepperoni
            {
                doughType = "thin",
                sauceType = "marinara"
            };
            if (type.Equals("cheese"))
                p.toppings.Add("cheese");
            return p;
        }
    }
}
