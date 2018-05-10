using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSight_IteratorDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BikeRepository repo = new BikeRepository();

            repo.addBike("Cervelo");
            repo.addBike("Scott");
            repo.addBike("Fuji");

            Iterator<string> bikeIterator = repo.iterator();

            while (bikeIterator.HasNext())
            {
                Console.WriteLine(bikeIterator.Next());
            }
        }
    }
}
