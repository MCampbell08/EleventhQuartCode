using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactoryDesignPattern
{
    public class PizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            if (type.Equals("cheese"))
                return new Cheese();
            else if (type.Equals("pep"))
                return new Pepperoni();
            else if (type.Equals("hawaiian"))
                return new Hawaiian();
            else if (type.Equals("meat"))
                return new MeatLovers();
            else if (type.Equals("veg"))
                return new Vegitarian();

            throw new Exception("We don't server your pizza here.");
        }
    }
}
