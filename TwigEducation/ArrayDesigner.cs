using System;
using System.Collections.Generic;
using System.Text;
using TwigEducation.Interfaces;

namespace TwigEducation
{
    public class ArrayDesigner : IArrayDesigner
    {
        private int[] Numbers;
        private int Divider;
        public ArrayDesigner(int[] numbers, int divider)
        {
            Numbers = numbers;
            Divider = divider;
        }

        private bool CheckNumberIsPositive() 
        {
            return Divider >= 0;
        }

        private bool CheckIfArrayHasData() 
        {
            return Numbers.Length > 0;
        }

        private bool CheckIfThereWontBeRemainder() 
        {
            return Numbers.Length % Divider == 0;
        }

        private int HowManyNumbersPerArray() 
        {
            return Numbers.Length / Divider;
        }

        private int RemainingAmount(int divider) 
        {
            return Numbers.Length % divider;
        }

        public int[][] StartProcess() 
        {
            if (!CheckIfArrayHasData()) throw new Exception("No data to split");
            if (!CheckNumberIsPositive()) throw new Exception("Divider is not positive");

            bool remains = CheckIfThereWontBeRemainder();
            int maxArray = CheckIfThereWontBeRemainder() ? HowManyNumbersPerArray() : HowManyNumbersPerArray() + 1;

            int position = 0;
            int[][] setUp = new int[Divider][];
            for (int i = 0; i < Divider; i++)
            {
                setUp[i] = (!remains && i == Divider -1) ? new int[RemainingAmount(maxArray)] : new int[maxArray];
                for (int j = 0; j < maxArray; j++)
                {
                    if (position < Numbers.Length)
                    {
                        setUp[i][j] = Numbers[position];
                        position++;
                    }
                }
            }

            return setUp;
        }

        public void PrintToScreen(int[][] arrays) 
        {
            Console.WriteLine("\n");
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    Console.Write(arrays[i][j] + " ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
