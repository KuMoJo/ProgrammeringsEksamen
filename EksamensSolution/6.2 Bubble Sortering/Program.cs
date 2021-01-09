using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2_Bubble_Sortering
{
    /// <summary>
    /// Implementerer en bubblesort der kan sortere et array.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSorter bubbleSorter = new BubbleSorter();

            int[] array = new int[]
            {
                2,
                4,
                1,
                7
            };

            bubbleSorter.BubbleSort(array);

            foreach(int value in array)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
