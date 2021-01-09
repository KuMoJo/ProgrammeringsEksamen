using System;
using System.Collections.Generic;
using _7._1_Grafbibliotek;
using _7._2_Tivoli_Graf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grafer_og_Soegning_Unit_Test
{
    [TestClass]
    public class GraferOgSoegningUnitTesting
    {
        [TestMethod]
        public void Test_Graph()
        {
            //Arrange
            Graph graph = new Graph();

            Node node1 = new Node("A");
            Node node2 = new Node("B");
            Node node3 = new Node("C");

            List<Node> expectedNodes = new List<Node>() { node1, node2, node3 };

            List<Edge> expectedEdges = new List<Edge>()
            {
                new Edge(node1, node2, $"{node1.Name}-{node2.Name}", Direction.BothWays),
                new Edge(node1, node3, $"{node1.Name}-{node3.Name}", Direction.BothWays)
            };


            //Act
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);

            node1.AddConnection(node2);
            node1.AddConnection(node3);

            graph.AddEdge(node1);


            //Assert
            CollectionAssert.AreEqual(expectedNodes, graph.Nodes);
            Assert.AreEqual(expectedEdges[0].Name, graph.Edges[0].Name);
            Assert.AreEqual(expectedEdges[1].Name, graph.Edges[1].Name);
        }


        [TestMethod]
        public void Test_Node()
        {
            //Arrange
            Node node1 = new Node("A");
            Node node2 = new Node("B");
            Node node3 = new Node("C");

            List<Node> expected = new List<Node>() { node2, node3 };


            //Act
            node1.AddConnection(node2);
            node1.AddConnection(node3);


            //Assert
            CollectionAssert.AreEqual(node1.Connections, expected);
        }


        [TestMethod]
        public void Test_DFS()
        {
            //Arrange
            #region Graf setup

            Graph2 tivoli = new Graph2();


            Node2 entrance = new Node2("Entrance");
            Node2 slotMachines = new Node2("Slot Machines");
            Node2 iceBlaster = new Node2("Ice Blaster");
            Node2 funHouse = new Node2("Fun House");
            Node2 hotDogs = new Node2("Hotdogs");
            Node2 logFlume = new Node2("Log Flume");
            Node2 bigDipper = new Node2("Big Dipper");
            Node2 rollercoaster = new Node2("Rollercoaster");
            Node2 ghostTrain = new Node2("Ghost Train");
            Node2 carousel = new Node2("Carousel");
            Node2 flyingChairs = new Node2("Flying Chairs");
            Node2 rocketShips = new Node2("Rocket Ships");
            Node2 _3DCinema = new Node2("3D Cinema");
            Node2 pirateShip = new Node2("Pirate Ship");


            tivoli.AddNode(entrance);
            tivoli.AddNode(slotMachines);
            tivoli.AddNode(iceBlaster);
            tivoli.AddNode(funHouse);
            tivoli.AddNode(hotDogs);
            tivoli.AddNode(logFlume);
            tivoli.AddNode(bigDipper);
            tivoli.AddNode(rollercoaster);
            tivoli.AddNode(ghostTrain);
            tivoli.AddNode(carousel);
            tivoli.AddNode(flyingChairs);
            tivoli.AddNode(rocketShips);
            tivoli.AddNode(_3DCinema);
            tivoli.AddNode(pirateShip);


            entrance.AddEdge(slotMachines);
            entrance.AddEdge(iceBlaster);
            entrance.AddEdge(funHouse);

            slotMachines.AddEdge(hotDogs);
            slotMachines.AddEdge(rocketShips);
            slotMachines.AddEdge(iceBlaster);

            iceBlaster.AddEdge(rocketShips);
            iceBlaster.AddEdge(funHouse);
            iceBlaster.AddEdge(_3DCinema);

            hotDogs.AddEdge(logFlume);

            logFlume.AddEdge(bigDipper);

            bigDipper.AddEdge(rollercoaster);
            bigDipper.AddEdge(ghostTrain);

            ghostTrain.AddEdge(carousel);
            ghostTrain.AddEdge(flyingChairs);

            carousel.AddEdge(flyingChairs);

            rocketShips.AddEdge(ghostTrain);
            rocketShips.AddEdge(_3DCinema);

            funHouse.AddEdge(_3DCinema);

            _3DCinema.AddEdge(pirateShip);


            tivoli.AddEdge(entrance);
            tivoli.AddEdge(slotMachines);
            tivoli.AddEdge(iceBlaster);
            tivoli.AddEdge(hotDogs);
            tivoli.AddEdge(logFlume);
            tivoli.AddEdge(bigDipper);
            tivoli.AddEdge(ghostTrain);
            tivoli.AddEdge(carousel);
            tivoli.AddEdge(rocketShips);
            tivoli.AddEdge(funHouse);
            tivoli.AddEdge(_3DCinema);

            #endregion

            Node2 expected = new Node2("Ghost Train");


            //Act
            Node2 actual = DFSManager.DFSearch(entrance, ghostTrain);


            //Assert
            Assert.AreEqual(expected.Name, actual.Name);
        }


        [TestMethod]
        public void Test_BFS()
        {
            //Arrange
            #region Graf setup

            Graph2 tivoli = new Graph2();


            Node2 entrance = new Node2("Entrance");
            Node2 slotMachines = new Node2("Slot Machines");
            Node2 iceBlaster = new Node2("Ice Blaster");
            Node2 funHouse = new Node2("Fun House");
            Node2 hotDogs = new Node2("Hotdogs");
            Node2 logFlume = new Node2("Log Flume");
            Node2 bigDipper = new Node2("Big Dipper");
            Node2 rollercoaster = new Node2("Rollercoaster");
            Node2 ghostTrain = new Node2("Ghost Train");
            Node2 carousel = new Node2("Carousel");
            Node2 flyingChairs = new Node2("Flying Chairs");
            Node2 rocketShips = new Node2("Rocket Ships");
            Node2 _3DCinema = new Node2("3D Cinema");
            Node2 pirateShip = new Node2("Pirate Ship");


            tivoli.AddNode(entrance);
            tivoli.AddNode(slotMachines);
            tivoli.AddNode(iceBlaster);
            tivoli.AddNode(funHouse);
            tivoli.AddNode(hotDogs);
            tivoli.AddNode(logFlume);
            tivoli.AddNode(bigDipper);
            tivoli.AddNode(rollercoaster);
            tivoli.AddNode(ghostTrain);
            tivoli.AddNode(carousel);
            tivoli.AddNode(flyingChairs);
            tivoli.AddNode(rocketShips);
            tivoli.AddNode(_3DCinema);
            tivoli.AddNode(pirateShip);


            entrance.AddEdge(slotMachines);
            entrance.AddEdge(iceBlaster);
            entrance.AddEdge(funHouse);

            slotMachines.AddEdge(hotDogs);
            slotMachines.AddEdge(rocketShips);
            slotMachines.AddEdge(iceBlaster);

            iceBlaster.AddEdge(rocketShips);
            iceBlaster.AddEdge(funHouse);
            iceBlaster.AddEdge(_3DCinema);

            hotDogs.AddEdge(logFlume);

            logFlume.AddEdge(bigDipper);

            bigDipper.AddEdge(rollercoaster);
            bigDipper.AddEdge(ghostTrain);

            ghostTrain.AddEdge(carousel);
            ghostTrain.AddEdge(flyingChairs);

            carousel.AddEdge(flyingChairs);

            rocketShips.AddEdge(ghostTrain);
            rocketShips.AddEdge(_3DCinema);

            funHouse.AddEdge(_3DCinema);

            _3DCinema.AddEdge(pirateShip);


            tivoli.AddEdge(entrance);
            tivoli.AddEdge(slotMachines);
            tivoli.AddEdge(iceBlaster);
            tivoli.AddEdge(hotDogs);
            tivoli.AddEdge(logFlume);
            tivoli.AddEdge(bigDipper);
            tivoli.AddEdge(ghostTrain);
            tivoli.AddEdge(carousel);
            tivoli.AddEdge(rocketShips);
            tivoli.AddEdge(funHouse);
            tivoli.AddEdge(_3DCinema);

            #endregion

            Node2 expected = new Node2("Ghost Train");


            //Act
            Node2 actual = BFSManager.BFSearch(entrance, ghostTrain);


            //Assert
            Assert.AreEqual(expected.Name, actual.Name);
        }
    }
}
