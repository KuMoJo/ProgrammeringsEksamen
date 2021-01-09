using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Tivoli_Graf
{
    /// <summary>
    /// En graf som repræsenteres af Nodes forbundet med Edges.
    /// </summary>
    public class Graph2
    //<TNode, TEdge>
    //where TNode : class
    //where TEdge : class
    {
        private List<Node2> nodes = new List<Node2>();
        private List<Edge2> edges = new List<Edge2>();

        public List<Node2> Nodes { get => nodes; set => nodes = value; }
        public List<Edge2> Edges { get => edges; set => edges = value; }


        /// <summary>
        /// Tilføjer en ny Node til grafen.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node2 node)
        {
            nodes.Add(node);
        }


        /// <summary>
        /// Tilføj en edge til grafen.
        /// </summary>
        /// <param name="node"></param>
        public void AddEdge(Node2 node)
        {
            //Hvis en Node har Nodes der er connected, så connect hver Connected Node til,
            //denne Node med en Edge.
            foreach (Edge2 edge in node.Edges)
            {
                Edges.Add(edge);
            }
        }


        /// <summary>
        /// Tegn grafen i console.
        /// </summary>
        public void DrawGraph()
        {
            //Udskriv hver Nodes navn.
            foreach (Node2 node in nodes)
            {
                Console.WriteLine(node.Name);

                //Udskriv hver Edges navn.
                foreach (Edge2 edge in node.Edges)
                {
                    Console.WriteLine($"   >{edge.Name}");
                }
            }
        }
    }
}
