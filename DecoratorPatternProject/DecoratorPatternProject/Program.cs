using System;

namespace DecoratorPatternProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DecoratorController decoratorController = new DecoratorController();

            decoratorController.Run();
        }
    }
}
