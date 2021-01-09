using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarMonoGameTest
{
    public class PathFinding
    {
        /// <summary>
        /// Den del af Astar som udregner vores vej fra Start til Target.
        /// </summary>
        /// <param name="startNode">Node du starter ved.</param>
        /// <param name="targetNode">Node du ønsker at finde en vej til fra startNode.</param>
        public void FindPath(Node startNode, Node targetNode)
        {
            //De nodes som skal undersøges.
            List<Node> openList = new List<Node>();

            //Nodes som allerede er blevet undersøgt.
            List<Node> closedList = new List<Node>();

            //Man starter altid med bare at tilføje startNode således,
            //at listen ikke er tom.
            openList.Add(startNode);

            //Så længe der er Nodes at undersøge, er vejen ikke fundet endnu.
            //Hvis man løber tør for Nodes i openList, så kunne vejen ikke findes.
            while (openList.Count > 0)
            {
                //Man skal altid starte med at definere en currentNode, så man kan sammenligne
                //de andre nodes i openList med hinanden.
                //Det er lidt ligemeget hvilken node man vælger.
                Node currentNode = openList[0];

                //Man sammenligner alle nodes på listen med den currentNode.
                for (int i = 0; i < openList.Count; i++)
                {

                    //Hvis en node har lavere FCost end currentNode, er den tættere på målet.
                    //Denne node er nu den nye currentNode som man flytter til.
                    //Hvis flere nodes har samme FCost, sammenligner man på HCost i stedet,
                    //da HCost bestemmer hvor tæt på man er på målet.
                    //Laveste HCost bliver da currentNode.
                    if (openList[i].FCost < currentNode.FCost || (openList[i].FCost == currentNode.FCost && openList[i].HCost < currentNode.HCost))
                    {
                        //Den currentNode bliver den node som er på den nuværende plads i openList.
                        currentNode = openList[i];
                    }
                }

                //Nu er currentNode blevet undersøgt, og den skal ikke tjekkes igen.
                //Derfor fjernes den fra openList og tilføjes til closedList.
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                //Tjek om den currentNode vi er på nu, er den node vi ønsker at finde en vej til.
                if (currentNode == targetNode)
                {
                    //Hvis det er, så definerer vejen fra start til end.
                    RetracePath(startNode, targetNode);
                    //Break i stedet for?
                    return;
                }

                //Nu skal man så lave et tjek på alle naboer til den currentNode,
                //hvis currentNode ikke var target.
                foreach (Node neighbour in GetNeighbours(currentNode))
                {
                    //Først tjekker man om den er non-walkable, 
                    //eller allerede er undersøgt (på closedList).
                    if (neighbour.Walkable != true || closedList.Contains(neighbour))
                    {
                        //Hvis ja, så fortsæt til næste neighbour i foreach-loopen.
                        continue;
                    }

                    //hvis den nye sti til naboen fra de nuværende er kortere end den gamle (nuværende sti), 
                    //eller naboen ikke er i den åbne 

                    //Definerer en GCost på neighbour. Den er tilsvarende currentNode GCost, som allerede er udregnet.
                    //plus den afstand der er fra currentNode til denne nabo.
                    //Hvis currentNode er startNode vil udregningen se således ud:
                    //"0 (startNode har ingen GCost) + 14 (afstanden mellem currentNode og startNode) = 14".
                    //Efterfølgende udregninger bygger videre på dette.
                    int newMovementCostToNeighbour = currentNode.GCost + CalculateDistance(currentNode, neighbour);

                    //Her skal vi tjekke, om den nuværende currentNode er den mest optimale.
                    //Det gør vi ved at sammenligne naboens nye GCost med den gamle.
                    //Hvis den ikke er på openList i forvejen, så har vi ikke noget at re-evaluere,
                    //og så skal den bare udregne resten i if-statement.
                    //Men hvis den allerede er på openList, så skal vi tjekke, 
                    //om den currentNode er optimal ved at sammenligne GCost.
                    //Hvis den nye GCost er lavere end før, så er dette en god sti.
                    //Man opdaterer da naboen til at passe med de nye værdier,
                    //og opdaterer Parent så det passer med currentNode.
                    if (newMovementCostToNeighbour < neighbour.GCost || !openList.Contains(neighbour))
                    {
                        //Naboens gCost er lige med distancen 
                        neighbour.GCost = newMovementCostToNeighbour;

                        //Naboens hCost er lig med afsanden fra naboen til tagetNode
                        neighbour.HCost = CalculateDistance(neighbour, targetNode);

                        //Sætter naboens parent tilden nuværende node den kom fra, så den altid ved hvem den kom fra. 
                        neighbour.Parent = currentNode;

                        if (!openList.Contains(neighbour))
                        {
                            openList.Add(neighbour);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Udregner afstanden mellem to Nodes.
        /// </summary>
        /// <param name="inputNode">Den node du starter fra.</param>
        /// <param name="targetNode">Den node du måler afstanden til.</param>
        /// <returns></returns>
        private int CalculateDistance(Node inputNode, Node targetNode)
        {
            //afstanden mellem de to noder, x og 
            //Man bestemmer afstanden mellem nodernes x og y-koordinater.
            //Abs (Absolute) bruges til at give resultatet som et positivt tal.
            //F.eks. er 4-5 = -1, men vi vil have det som 1, da vi kun er interessert i differencen
            //mellem de to koordinater.
            int dstX = Math.Abs((int)inputNode.GetCoordinate().X - (int)targetNode.GetCoordinate().X);
            int dstY = Math.Abs((int)inputNode.GetCoordinate().Y - (int)targetNode.GetCoordinate().Y);

            //Se eventuelt den vedlagte tegning.
            //Hvis afstanden mellem de to noder er højere i bredden end i højden.
            if (dstX > dstY)
            {
                //Denne formel definerer hvordan vi finder afstanden mellem de to.
                //formel: n =  y + (x-y)
                //formel med ganget op: n = 14y + 10*(x-y);

                //Y-afstanden er hvor langt den går op, men diagonalt.
                //Altså hvis differencen på y mellem de to noder er 1,
                //så skal man gå skråt 1 gang på vejen (14 x 1)-
                //Derefter finder man ud af, hvor langt man skal bevæge sig ad x-aksen for at få afstanden.
                //Det gør man ved at trække det laveste tal (denne gang y) fra det højeste (x) for at finde 
                //hvor langt den resterende x-strækning er. 

                return 14 * dstY + 10 * (dstX - dstY);
            }

            else
            {
                //det omvendte hvis y er større. 
                //x-differencen bestemmer hvor mange gange man skal gå skråt.
                //resultatet af y-differencen minus x-differencen bestemmer hvor mange gange man skal gå lige.
                return 14 * dstX + 10 * (dstY - dstX);
            }
        }


        /// <summary>
        /// Bruges når man skal finde den path som blev taget fra startNode til endNode i FindPath.
        /// </summary>
        /// <param name="startNode"></param>
        /// <param name="endNode"></param>
        public List<Node> RetracePath(Node startNode, Node endNode)
        {
            //En liste til nodes på stien.
            List<Node> path = new List<Node>();

            //Starter ved den sidste node, altså fra goal.
            //Derefter kan man bevæge sig tilbage.
            Node currentNode = endNode;

            //Så længe man ikke er nået til starten, så skal man blive ved med at tilføje nodes til listen.
            while (currentNode != startNode)
            {
                //Ændrer bare på sprite.
                //Ændrer kun hvis det ikke er en unit test.
                if (currentNode.IsTest == false)
                {
                    currentNode.Sprite = GameWorld.pathSprite;
                }

                //Tilføjer den nuværende node til Sti listen
                path.Add(currentNode);

                //Sætter den nuværende node til at være lig med den nuværende nodes Parent node. 
                //Dvs den næste i stien eller der hvor currentNode kom fra.
                //Således kan man gennem parents gå gennem stien fra end til start.
                currentNode = currentNode.Parent;
            }

            //Fordi listen starter fra slut og går mod start, skal den køres omvendt.
            path.Reverse();

            return path;
        }


        /// <summary>
        /// Skaffer alle naboer til den valgte node.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private List<Node> GetNeighbours(Node node)
        {
            //Liste som skal returneres, når den er udfyldt.
            List<Node> neighbours = new List<Node>();

            //Tjekker et 3x3 grid rundt om nuværende node.
            //Man tjekker positionerne relativt for denne.
            //Altså den node hvor f.eks. x er lig -1 af nuværende nodes x,
            //og y er lig -+0 af nuværende nodes y (det samme).
            for (int x = -1; x <= 1; x++)
            {
                //-1 x = x på venstre side af node.
                //0 x  = samme x som node.
                //1 x  = x på højre side af node.
                for (int y = -1; y <= 1; y++)
                {
                    //-1 y = y over node.
                    //0 y  = samme y som node.
                    //1 y  = y under node.

                    //0,0 er nodes egen position og skal ikke tælles med.
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    //Der bliver brugt GetCoordinate så hver tile er fx 1,2,3 osv istedet for 450. 468 etc.
                    //Gemmer den position den er nået til i forloopet.
                    //Man tage den nuværendes nodes x eller y og lægger det x eller y, som for-loop er,
                    //(-1, 0, 1). Således kan den finde nabo-nodes position i forhold til dette.
                    //Altså hvis nuværende node har x = 1 og for-loop er på -1, så ser ligningen sådan ud:
                    //"nuværendeNode.X (x = 1) + (-1) = naboNode.X = 0.
                    //Så kan den lave tjek på denne position.
                    int checkX = (int)node.GetCoordinate().X + x;
                    int checkY = (int)node.GetCoordinate().Y + y;

                    //Tjekker om det er inden for 10x10 gridet der er "banen"
                    //Ellers er den uden for banen og skal ikke tælles med.
                    if (checkX >= 0 && checkX < 10 && checkY >= 0 && checkY < 10)
                    {
                        //Man tilføjer til neighbours-listen fra nodes-arrayet den node,
                        //hvor den x og y er tilsvarende checkX og checkY.
                        neighbours.Add(GameWorld.nodes[checkX, checkY]);
                    }
                }
            }

            //Når forloopet er gennemgået kan man returnere listen af naboer.
            return neighbours;
        }
    }
}
