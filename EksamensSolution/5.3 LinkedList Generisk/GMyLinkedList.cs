using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._3_LinkedList_Generisk
{
    /// <summary>
    /// Definerer en generisk LinkedList.
    /// </summary>
    public class GMyLinkedList<GMyNode> : IEnumerable<GMyNode>
    {
        private GMyNode<GMyNode> first;
        private GMyNode<GMyNode> last;

        public GMyNode<GMyNode> First { get => first; set => first = value; }
        public GMyNode<GMyNode> Last { get => last; set => last = value; }


        /// <summary>
        /// Indsæt en Node til sidst i MyLinkedList.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public GMyNode<GMyNode> AddLast(GMyNode node)
        {
            GMyNode<GMyNode> toAdd = new GMyNode<GMyNode>(node);

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
            return Last;
        }


        /// <summary>
        /// Indsæt en Node forrest i MyLinkedList.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public GMyNode<GMyNode> AddFirst(GMyNode node)
        {
            GMyNode<GMyNode> toAdd = new GMyNode<GMyNode>(node);

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
            return First;
        }


        public IEnumerator<GMyNode> GetEnumerator()
        {
            GMyNode<GMyNode> current = First;

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
