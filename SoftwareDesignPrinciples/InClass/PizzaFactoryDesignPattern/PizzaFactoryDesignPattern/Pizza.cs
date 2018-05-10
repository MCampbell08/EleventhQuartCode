using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactoryDesignPattern
{
    public class Pizza
    {
        public string doughType;
        public string sauceType;
        public List<string> toppings = new List<string>();
        public void Box()
        {
            Console.WriteLine("Boxing your pizza, it was a knockout... ;)");
        }
        public void Cut()
        {
            Console.WriteLine("Cutting pizza into 30 tiny pieces.");
        }
        public void Bake()
        {
            Console.WriteLine("Baking at 350 for 15 minutes.");
        }
    }
}
