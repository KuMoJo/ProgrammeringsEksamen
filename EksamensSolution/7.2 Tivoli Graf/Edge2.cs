using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Tivoli_Graf
{
    /// <summary>
    /// Klasse der kan definere en Edge i en graf og forbinde Nodes.
    /// </summary>
    public class Edge2
    {
        //De to nodes som Edge forbinder.
        private Node2 startNode;
        private Node2 endNode;
        //Navn til Edge.
        private string name;

        public string Name { get => name; set => name = value; }
        public Node2 StartNode { get => startNode; set => startNode = value; }
        public Node2 EndNode { get => endNode; set => endNode = value; }


        public Edge2(Node2 node, Node2 connectedNode, string name)
        {
            StartNode = node;
            EndNode = connectedNode;
            Name = name;
        }
    }
}
