using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1_Grafbibliotek
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();


            Node node1;
            Node node2;
            Node node3;
            Node node4;


            graph.AddNode(node1 = new Node("A"));
            graph.AddNode(node2 = new Node("B"));
            graph.AddNode(node3 = new Node("C"));
            graph.AddNode(node4 = new Node("D"));


            node1.AddConnection(node2);
            node3.AddConnection(node4);


            graph.AddEdge(node1);
            graph.AddEdge(node3);


            graph.DrawGraph();

            Console.ReadLine();
        }
    }
}
