using System;
using System.Collections.Generic;
using _6._1_Insertion_Sortering;
using _6._2_Bubble_Sortering;
using _6._3_Quick_Sortering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sortering_Unit_Test
{
    [TestClass]
    public class SorteringUnitTesting
    {
        [TestMethod]
        public void Test_InsertionSortering()
        {
            //Arrange
            int[] array1 = new int[]
            {
                1,
                4,
                7,
                2,
            };

            int[] array2 = new int[]
            {
                1,
                2,
                4,
                7,
            };

            InsertionSorter insertionSorter = new InsertionSorter();


            //Act
            insertionSorter.InsertionSort(array1);


            //Assert
            CollectionAssert.AreEqual(array1, array2);
        }


        [TestMethod]
        public void Test_BubbleSortering()
        {
            //Arrange
            int[] array1 = new int[]
            {
                1,
                4,
                7,
                2,
            };

            int[] array2 = new int[]
            {
                1,
                2,
                4,
                7,
            };

            BubbleSorter bubbleSorter = new BubbleSorter();


            //Act
            bubbleSorter.BubbleSort(array1);


            //Assert
            CollectionAssert.AreEqual(array1, array2);
        }


        [TestMethod]
        public void Test_QuickSortering()
        {
            //Arrange
            List<int> list1 = new List<int>()
            {
                1,
                4,
                7,
                2,
            };

            List<int> list2 = new List<int>()
            {
                1,
                2,
                4,
                7,
            };

            QuickSorter quickSorter = new QuickSorter();


            //Act
            list1 = quickSorter.QuickSort(list1);


            //Assert
            CollectionAssert.AreEqual(list1, list2);
        }
    }
}
