using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3_Quick_Sortering
{
    /// <summary>
    /// Implementer quicksort således man kan sortere en liste eller et array.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            QuickSorter quickSorter = new QuickSorter();

            List<int> list = new List<int>()
            {
                2,
                4,
                7,
                1
            };

            //Man er nødt til at definere listen således, ellers virker det ikke.
            list = quickSorter.QuickSort(list);

            foreach(int value in list)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
