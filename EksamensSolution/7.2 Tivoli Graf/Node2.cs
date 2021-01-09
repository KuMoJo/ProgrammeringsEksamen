using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Tivoli_Graf
{
    /// <summary>
    /// En Node som kan indgå i en graf og forbindes til andre Nodes med Edges.
    /// </summary>
    public class Node2
    {
        //Liste over Nodes som denne Node er forbundet til.
        private List<Edge2> edges = new List<Edge2>();
        //Navn på denne Node.
        private string name;
        private Node2 parent;
        private bool discovered;
        private Node2 child;

        public List<Edge2> Edges { get => edges; set => edges = value; }
        public string Name { get => name; set => name = value; }
        public Node2 Parent { get => parent; set => parent = value; }
        public bool Discovered { get => discovered; set => discovered = value; }
        public Node2 Child { get => child; set => child = value; }


        public Node2(string name)
        {
            Name = name;
            Discovered = false;
        }


        /// <summary>
        /// Forbinder en ny Node til denne Node.
        /// </summary>
        /// <param name="connectedNode"></param>
        public void AddEdge(Node2 connectedNode)
        {
            Edges.Add(new Edge2(this, connectedNode, $"{Name}-{connectedNode.Name}"));
        }
    }
}
