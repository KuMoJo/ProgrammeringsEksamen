using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2_LinkedList_Ikke_generisk
{
    /// <summary>
    /// Definerer en LinkedList.
    /// </summary>
    public class MyLinkedList : IEnumerable
    {
        private MyNode first;
        private MyNode last;

        public MyNode First { get => first; set => first = value; }
        public MyNode Last { get => last; set => last = value; }


        /// <summary>
        /// Indsæt en Node til sidst i MyLinkedList.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void AddLast(object node)
        {
            MyNode toAdd = new MyNode(node);

            //Hvis der ikke er nogen Last, så er der ingen Nodes i forvejen.
            //Den skal da tilføjes som First, da den både er First og Last.
            if (Last == null)
            {
                First = toAdd;
            }

            //Hvis der allerede eksistere mindst én Node,
            //så skal denne Node tilføjes som dens previous.
            else
            {
                Last.Next = toAdd;
                //Den forrige Last bliver da den nye Nodes Previous.
                toAdd.Previous = Last;

                //En Next der er null indikerer, at dette er den sidste Node.
                toAdd.Next = null;
            }

            //Node tilføjes som Last.
            Last = toAdd;
        }


        /// <summary>
        /// Indsæt en Node forrest i MyLinkedList.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void AddFirst(Object node)
        {
            MyNode toAdd = new MyNode(node);

            //Hvis der ikke er nogen First, så er denne Node den første der tilføjes.
            //Den skal da tilføjes som Last, da den både er First og Last.
            if (First == null)
            {
                Last = toAdd;
            }

            //Hvis der allerede eksistere mindst én Node,
            //så skal denne Node tilføjes som dens previous.
            else
            {
                First.Previous = toAdd;
                //Den forrige First bliver da den nye Nodes Next.
                toAdd.Next = First;

                //En previous der er null indikerer, at dette er den forreste Node.
                toAdd.Previous = null;
            }

            //Node tilføjes som First.
            First = toAdd;
        }


        public IEnumerator GetEnumerator()
        {
            MyNode current = First;

            while (current != null)
            {
                //Yield sørger for at koden starter her ved næste eksekvering.
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
