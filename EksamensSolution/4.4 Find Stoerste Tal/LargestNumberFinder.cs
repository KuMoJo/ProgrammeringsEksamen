using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._4_Find_Stoerste_Tal
{
    public class LargestNumberFinder
    {
        public int FindLargestNumber(int[] numbers)
        {
            int largestNumber = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > largestNumber)
                {
                    largestNumber = numbers[i];
                }
            }

            return largestNumber;

            throw new IndexOutOfRangeException("Something went wrong...");
        }
    }
}
