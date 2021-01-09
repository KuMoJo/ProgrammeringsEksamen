using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2_LinkedList_Ikke_generisk
{
    /// <summary>
    /// Lav en LinkedList som bruger objects (ikke-generisk)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new MyLinkedList();

            myLinkedList.AddFirst(4);
            myLinkedList.AddFirst(3);
            myLinkedList.AddFirst(2);
            myLinkedList.AddFirst(1);
            myLinkedList.AddLast(5);


            //Lav en gennemgang af myLinkedList, her bruges IEnumerator.
            foreach (int item in myLinkedList)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
