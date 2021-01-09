using System;
using System.Collections.Generic;
using AStarMonoGameTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Astar_Unit_Test
{
    [TestClass]
    public class AstarUnitTesting
    {
        [TestMethod]
        public void Test_Astar()
        {
            //Assert
            Node[,] nodeGrid = new Node[5, 5];
            List<Node> nodes = new List<Node>();

            NodeType type;
            bool walkable;
            string coordinates ;

            //Udfyld grid.
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    coordinates = $"{x},{y}";

                    if (x == 0 && y == 0)
                    {
                        type = NodeType.Enemy;
                        walkable = true;
                    }

                    if (x == 4 && y == 4)
                    {
                        type = NodeType.Goal;
                        walkable = true;
                    }

                    if (x == 3 && (y == 0 || y == 2 || y == 3 || y == 4))
                    {
                        type = NodeType.Tower;
                        walkable = false;
                    }

                    else
                    {
                        type = NodeType.Empty;
                        walkable = true;
                    }

                    Node tmp = new Node(type, walkable, coordinates);

                    nodes.Add(tmp);
                    //Og vi tilføjer denne node til arrayet af nodes, så vi kan undersøge dem,
                    //og holde styr på dem.
                    nodeGrid[x, y] = tmp;
                }

                Node tmpStart = new Node(NodeType.Empty, true, null);
                Node tmpGoal = new Node(NodeType.Empty, true, null);

                foreach (Node nO in nodes)
                {
                    if (nO.Type == NodeType.Enemy)
                    {
                        tmpStart = nO;
                    }
                    else if (nO.Type == NodeType.Goal)
                    {
                        tmpGoal = nO;
                    }
                }

                PathFinding pathFinding = new PathFinding();

                pathFinding.FindPath(tmpStart, tmpGoal);

                List<string> expectedPath = new List<string>()
                {
                    "0,0",
                    "1,1",
                    "2,1",
                    "3,1",
                    "4,2",
                    "4,3",
                };

                List<Node> nodePath = new List<Node>();
                List<string> actualPath = new List<string>();


                //Act
                nodePath = pathFinding.RetracePath(tmpStart, tmpGoal);

                foreach (Node node in nodePath)
                {
                    actualPath.Add(node.Coordinates);
                }


                //Assert
                CollectionAssert.AreEqual(expectedPath, actualPath);
            }
        }
    }
}
