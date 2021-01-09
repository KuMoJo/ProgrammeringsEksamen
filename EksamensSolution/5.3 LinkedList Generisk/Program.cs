using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._3_LinkedList_Generisk
{
    /// <summary>
    /// Lav en LinkedList som er generisk.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            GMyLinkedList<int> myLinkedList = new GMyLinkedList<int>();

            myLinkedList.AddFirst(1);
            myLinkedList.AddFirst(2);
            myLinkedList.AddFirst(3);
            myLinkedList.AddFirst(4);
            myLinkedList.AddLast(0);


            //Lav en gennemgang af myLinkedList, her bruges IEnumerator.
            foreach (int item in myLinkedList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
