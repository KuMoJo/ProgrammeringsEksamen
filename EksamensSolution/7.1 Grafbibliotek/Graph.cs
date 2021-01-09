using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1_Grafbibliotek
{
    /// <summary>
    /// En graf som repræsenteres af Nodes forbundet med Edges.
    /// </summary>
    public class Graph
        //<TNode, TEdge>
        //where TNode : class
        //where TEdge : class
    {
        private List<Node> nodes = new List<Node>();
        private List<Edge> edges = new List<Edge>();

        public List<Node> Nodes { get => nodes; set => nodes = value; }
        public List<Edge> Edges { get => edges; set => edges = value; }


        /// <summary>
        /// Tilføjer en ny Node til grafen.
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(Node node)
        {
            nodes.Add(node);
        }


        /// <summary>
        /// Tilføj en edge til grafen.
        /// </summary>
        /// <param name="node"></param>
        public void AddEdge(Node node)
        {
            //Hvis en Node har Nodes der er connected, så connect hver Connected Node til,
            //denne Node med en Edge.
            foreach (Node connectedNode in node.Connections)
            {
                edges.Add(new Edge(node, connectedNode, $"{node.Name}-{connectedNode.Name}", Direction.BothWays));
            }
        }


        /// <summary>
        /// Tegn grafen i console.
        /// </summary>
        public void DrawGraph()
        {
            //Udskriv hver Nodes navn.
            foreach (Node node in nodes)
            {
                Console.WriteLine(node.Name);

                //Udskriv hver Edges navn.
                foreach (Edge edge in edges)
                {
                    Console.WriteLine($"{edge.Name}, {edge.Direction.ToString()}");
                }
            }
        }
    }
}
