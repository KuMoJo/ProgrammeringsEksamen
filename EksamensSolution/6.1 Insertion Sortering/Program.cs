using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1_Insertion_Sortering
{
    /// <summary>
    /// Implementer en insertionsort der kan sortere et array.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[]
            {
                1,
                4,
                7,
                2,
            };

            InsertionSorter insertionSorter = new InsertionSorter();

            insertionSorter.InsertionSort(array);

            foreach (int value in array)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
