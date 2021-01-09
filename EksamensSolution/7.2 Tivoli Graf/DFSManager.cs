using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Tivoli_Graf
{
    /// <summary>
    /// Anvendes til at lave Dybde Først Søgning på en graf.
    /// </summary>
    public class DFSManager
    {
        private static List<Node2> parents = new List<Node2>();


        /// <summary>
        /// Bruges til at skrive søgningen path ud i konsollen.
        /// </summary>
        /// <param name="path"></param>
        public static void RetracePath()
        {
            foreach (Node2 node in parents)
            {
                Console.WriteLine($"{node.Name}->{node.Child.Name}");
            }
        }


        /// <summary>
        /// Foretag en Dybde Først Søgning på en graf.
        /// </summary>
        /// <param name="startNode">Node du starter søgningen fra.</param>
        /// <param name="goalNode">Node du ønsker at finde.</param>
        public static Node2 DFSearch(Node2 startNode, Node2 goalNode)
        {
            //Node der skal retuneres når goal er fundet.
            Node2 returnNode = new Node2("NodeNotFound");

            //En stack som kan holde styr på de edges som skal undersøges lige nu.
            //Stack er god fordi du kan bruge Pop og Push.
            Stack<Edge2> edgeStack = new Stack<Edge2>();

            //Tilføj din en edge der bare er fra og til din start Node.
            //Bare så man har et sted at starte fra.
            edgeStack.Push(new Edge2(startNode, startNode, $"{startNode.Name}-{startNode.Name}"));

            //Så længe der er ting at undersøge i stack skal man blive ved.
            //Hvis man når 0 må hele grafen være gennemgået.
            while (edgeStack.Count > 0)
            {
                //Hent den øverste Edge på Stack.
                Edge2 edge = edgeStack.Pop();

                Console.WriteLine(edge.Name);

                //Hvis Node for enden af Edge ikke har været opdaget før.
                if (!edge.EndNode.Discovered)
                {
                    //Sæt den til at være opdaget.
                    edge.EndNode.Discovered = true;
                    //Og sæt dens parent til at være den Node du kom fra.
                    //Dette kan man bruge hvis man skal retrace sin vej hen til goal, når goal er fundet.
                    edge.EndNode.Parent = edge.StartNode;
                    edge.StartNode.Child = edge.EndNode;
                    //Tilføj dens parent til listen så man kan gennemgå søgningen path igen.
                    parents.Add(edge.EndNode.Parent);

                    Console.WriteLine($"    >{edge.EndNode.Name}");
                }

                //Tjek også om den Node for enden af Edge er goal.
                //Fjern hvis du vil gennemsøge hele grafen i stedet for.
                if (edge.EndNode == goalNode)
                {
                    Console.WriteLine("Goal Found");
                    returnNode = edge.EndNode;
                    //Hvis den er kan du bryde ud af while og stoppe søgningen.
                    break;
                }

                //Når Node for enden af edgen er tjekket, så kan man tjekke,
                //hvilke edges der er forbundet til denne.
                foreach (Edge2 e in edge.EndNode.Edges)
                {
                    Console.WriteLine(e.Name);

                    //Hvis de Nodes der er for enden af denne edge ikke er opdaget,
                    //så skal edge e tilføjes til Stack så den kan blive tjekket i de næste while-loop.
                    //Hvis ikke den har nogen Edges koblet til sig, så er det en dead end.
                    //I dette tilfælde vil næste loop starte fra den sidste edge den kender,
                    //altså den til Noden før denne.
                    if (!e.EndNode.Discovered)
                    {
                        edgeStack.Push(e);
                    }
                }
            }

            return returnNode;
        }
    }
}
