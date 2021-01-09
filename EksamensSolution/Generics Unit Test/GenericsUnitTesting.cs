using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _5._2_LinkedList_Ikke_generisk;
using _5._3_LinkedList_Generisk;
using _5._1_Generisk_Swap_Metode;
using System.Collections.Generic;
using _5._4_Highscore_Sortering;

namespace Generics_Unit_Test
{
    [TestClass]
    public class GenericsUnitTesting
    {
        [TestMethod]
        public void Test_MySwap()
        {
            //Arrange
            MySwap mySwap = new MySwap();
            int firstInt = 1;
            int secondInt = 2;
            int expected = 2;

            //Act
            mySwap.Swap(ref firstInt, ref secondInt);

            //Assert
            Assert.AreEqual(expected, firstInt);
        }


        [TestMethod]
        public void Test_LinkedListIkkeGenerisk()
        {
            //Arrange
            MyLinkedList linkedList = new MyLinkedList();
            int expectedLast = 5;

            //Act
            linkedList.AddFirst(10);
            linkedList.AddLast(5);

            //Assert
            Assert.AreEqual(expectedLast, linkedList.Last.Value);
        }

        [TestMethod]
        public void Test_LinkedListGenerisk()
        {
            //Arrange
            GMyLinkedList<int> linkedList = new GMyLinkedList<int>();
            int expectedLast = 20;

            //Act
            linkedList.AddLast(20);
            linkedList.AddFirst(15);

            //Assert
            Assert.AreEqual(expectedLast, linkedList.Last.Value);
        }


        [TestMethod]
        public void Test_HighscoreSortering()
        {
            //Arrange
            Highscore highscore1 = new Highscore("Stinna", 1000);
            Highscore highscore2 = new Highscore("Emma", 500);

            int expected = -1;
            
            //Act
            //Hvis highscore1 er større end highscore2 burde actual være -1.
            int actual = highscore1.CompareTo(highscore2);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
