using System;
using TwigEducation.Interfaces;

namespace TwigEducation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };
            int split = 3;

            IArrayDesigner Designer = new ArrayDesigner(numbers, split);

            int[][] arrays = Designer.StartProcess();

            Console.WriteLine("Would you like to print the arrays to screen? (Y,N)");

            if (Console.ReadLine().ToUpper() == "Y")
            {
                Designer.PrintToScreen(arrays);
                Console.ReadLine();
            }
        }
    }
}
