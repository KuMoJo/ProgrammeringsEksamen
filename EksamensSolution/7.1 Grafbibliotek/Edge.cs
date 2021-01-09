using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1_Grafbibliotek
{
    public enum Direction { FromHere, FromThere, BothWays } 

    /// <summary>
    /// Klasse der kan definere en Edge i en graf og forbinde Nodes.
    /// </summary>
    public class Edge
    {
        //De to nodes som Edge forbinder.
        private Node node;
        private Node connectedNode;
        //Navn til Edge.
        private string name;
        private Direction direction;

        public string Name { get => name; set => name = value; }
        public Node Node { get => node; set => node = value; }
        public Node ConnectedNode { get => connectedNode; set => connectedNode = value; }
        public Direction Direction { get => direction; set => direction = value; }


        public Edge(Node node, Node connectedNode, string name, Direction direction)
        {
            Node = node;
            ConnectedNode = connectedNode;
            Name = name;
            Direction = direction;
        }
    }
}
