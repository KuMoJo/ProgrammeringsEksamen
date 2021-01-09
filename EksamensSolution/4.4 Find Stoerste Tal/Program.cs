using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4_Find_Stoerste_Tal
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 3, 5, 6, 4, 2, 8, 9 };

            int largestNumber = default;


            LargestNumberFinder largestNumberFinder = new LargestNumberFinder();


            largestNumber = largestNumberFinder.FindLargestNumber(numbers);

            Console.WriteLine(largestNumber);


            Console.ReadLine();
        }
    }
}
