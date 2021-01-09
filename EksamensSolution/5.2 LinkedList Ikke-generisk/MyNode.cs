using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2_LinkedList_Ikke_generisk
{
    /// <summary>
    /// Definerer en Node på MyLinkedList.
    /// </summary>
    public class MyNode
    {
        private object value;
        private MyNode previous;
        private MyNode next;

        public MyNode Previous { get => previous; set => previous = value; }
        public MyNode Next { get => next; set => next = value; }
        public object Value { get => value; }


        /// <summary>
        /// Få den næste Node.
        /// </summary>
        /// <returns></returns>
        public MyNode(object value)
        {
            this.value = value;
        }
    }
}
