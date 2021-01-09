using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._2_Tivoli_Graf
{
    /// <summary>
    /// Implementer tivoliparken fra eksemplet.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
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


            //tivoli.DrawGraph();


            //DFSManager.DFSearch(entrance, ghostTrain);
            //Console.ReadLine();
            //DFSManager.RetracePath();

            BFSManager.BFSearch(entrance, ghostTrain);
            Console.ReadLine();
            BFSManager.RetracePath();


            Console.ReadLine();
        }
    }
}
