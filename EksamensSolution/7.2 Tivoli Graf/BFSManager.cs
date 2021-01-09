using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Tivoli_Graf
{
    /// <summary>
    /// Anvendes til at lave Bredde Først Søgning på en graf.
    /// </summary>
    public class BFSManager
    {
        private static List<Node2> path = new List<Node2>();


        /// <summary>
        /// Bruges til at skrive søgningen path ud i konsollen.
        /// </summary>
        /// <param name="path"></param>
        public static void RetracePath()
        {
            foreach (Node2 node in path)
            {
                Console.WriteLine($"{node.Name}->{node.Child.Name}");
            }
        }


        /// <summary>
        /// Foretag en Bredde Først Søgning på en graf.
        /// </summary>
        /// <param name="startNode">Node du starter søgningen fra.</param>
        /// <param name="goalNode">Node du ønsker at søge efter.</param>
        public static Node2 BFSearch(Node2 startNode, Node2 goalNode)
        {
            //Node der skal retuneres når goal er fundet.
            Node2 returnNode = new Node2("NodeNotFound");

            //Ved at bruge Queue i stedet for Stack kan man søge i bredden i stedet for dybden.
            //Det er fordi Queue er First In First Out, så nye edges der findes bliver først gennemgået,
            //efter de edges der allerede er i køen er gennemgået.
            Queue<Edge2> edgeQueue = new Queue<Edge2>();

            //Igen tilføjer man bare en start edge på startNode.
            edgeQueue.Enqueue(new Edge2(startNode, startNode, $"{startNode.Name}-{startNode.Name}"));

            //Så længe der er ting i køen, er der stadig ting som skal undersøges i grafen.
            while (edgeQueue.Count > 0)
            {
                //Hent den edge som er forrest i køen.
                Edge2 edge = edgeQueue.Dequeue();

                //Tjek også om den Node for enden af Edge er goal.
                //Fjern hvis du vil gennemsøge hele grafen i stedet for.
                if (edge.EndNode == goalNode)
                {
                    Console.WriteLine("Goal Found");
                    returnNode = edge.EndNode;
                    //Hvis den er kan du bryde ud af while og stoppe søgningen.
                    break;
                }

                //Tjek alle edges der er koblet til denne edges endeNode.
                foreach (Edge2 e in edge.EndNode.Edges)
                {
                    //Hvis de Nodes der er for enden af denne edge ikke er opdaget,
                    //så skal edge e tilføjes til Queue så den kan blive tjekket i de næste while-loop.
                    //Hvis ikke den har nogen Edges koblet til sig, så er det en dead end.
                    //I dette tilfælde vil næste loop starte fra den sidste edge den kender,
                    //altså den til Noden før denne.
                    if (!e.EndNode.Discovered)
                    {
                        edgeQueue.Enqueue(e);

                        //Sæt den til at være opdaget.
                        edge.EndNode.Discovered = true;
                        //Og sæt dens parent til at være den Node du kom fra.
                        //Dette kan man bruge hvis man skal retrace sin vej hen til goal, når goal er fundet.
                        edge.EndNode.Parent = edge.StartNode;
                        edge.StartNode.Child = edge.EndNode;
                        //Tilføj dens parent til listen så man kan gennemgå søgningen path igen.
                        path.Add(edge.EndNode.Parent);

                        Console.WriteLine($"    >{edge.EndNode.Name}");
                    }
                }
            }

            return returnNode;
        }
    }
}
