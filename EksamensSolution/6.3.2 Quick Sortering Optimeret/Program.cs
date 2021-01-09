using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3._2_Quick_Sortering_Optimeret
{
    /// <summary>
    /// Implementer en optimerert version af QuickSort, som kan sortere en liste eller et array.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            QuickSorterOptimized quickSorterOptimized = new QuickSorterOptimized();

            List<int> list = new List<int>()
            {
                2,
                4, 
                7,
                1
            };

            //list = quickSorterOptimized.Partition2(list);

            foreach(int value in list)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
