using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._3_LinkedList_Generisk
{
    /// <summary>
    /// Definerer en Node på MyLinkedList.
    /// </summary>
    public class GMyNode<T>
    {
        private T value;
        private GMyNode<T> previous;
        private GMyNode<T> next;

        public GMyNode<T> Previous { get => previous; set => previous = value; }
        public GMyNode<T> Next { get => next; set => next = value; }
        public T Value { get => value;}


        /// <summary>
        /// Få den næste Node.
        /// </summary>
        /// <returns></returns>
        public GMyNode(T value)
        {
            this.value = value;
        }
    }
}
