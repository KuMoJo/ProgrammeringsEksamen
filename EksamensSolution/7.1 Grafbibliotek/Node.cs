using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1_Grafbibliotek
{
    /// <summary>
    /// En Node som kan indgå i en graf og forbindes til andre Nodes med Edges.
    /// </summary>
    public class Node
    {
        //Liste over Nodes som denne Node er forbundet til.
        private List<Node> connections = new List<Node>();
        //private Node connection;
        //Navn på denne Node.
        private string name;

        public List<Node> Connections { get => connections; set => connections = value; }
        public string Name { get => name; set => name = value; }


        public Node(string name)
        {
            this.Name = name;
        }


        /// <summary>
        /// Forbinder en ny Node til denne Node.
        /// </summary>
        /// <param name="connectedNode"></param>
        public void AddConnection(Node connectedNode)
        {
            Connections.Add(connectedNode);
        }
    }
}
