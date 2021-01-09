using _4._1_Unit_Test_Opgave;
using _4._2_Togbillet_Priser;
using _4._3_Find_Maaned;
using _4._4_Find_Stoerste_Tal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Unit_Test
{
    [TestClass]
    public class TestUnitTesting
    {
        #region Calculator

        [TestMethod]
        public void Test_CalculatorAdd()
        {
            //Arrange
            Calculator calculator = new Calculator();

            int first = 10;
            int second = 15;
            int expected = 25;

            //Act
            int actual = calculator.Add(first, second);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region PriceCalculator

        [TestMethod]
        public void Test_0til2_PriceCalculator()
        {
            //Arrange
            PriceCalculator priceCalculator = new PriceCalculator();

            int age = 1;
            int expectedPrice = 0;

            //Act
            int actualPrice = priceCalculator.CalculatePrice(age);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [TestMethod]
        public void Test_2til14_PriceCalculator()
        {
            //Arrange
            PriceCalculator priceCalculator = new PriceCalculator();

            int age = 6;
            int expectedPrice = 10;

            //Act
            int actualPrice = priceCalculator.CalculatePrice(age);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [TestMethod]
        public void Test_15til64_PriceCalculator()
        {
            //Arrange
            PriceCalculator priceCalculator = new PriceCalculator();

            int age = 40;
            int expectedPrice = 20;

            //Act
            int actualPrice = priceCalculator.CalculatePrice(age);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [TestMethod]
        public void Test_65over_PriceCalculator()
        {
            //Arrange
            PriceCalculator priceCalculator = new PriceCalculator();

            int age = 75;
            int expectedPrice = 5;

            //Act
            int actualPrice = priceCalculator.CalculatePrice(age);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }


        [TestMethod]
        public void Test_UgyldigAlder_PriceCalculator()
        {
            //Arrange
            PriceCalculator priceCalculator = new PriceCalculator();

            int age = -10;
            int expectedPrice = -1;

            //Act
            int actualPrice = priceCalculator.CalculatePrice(age);

            //Assert
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        #endregion


        #region MonthDeterminer

        [TestMethod]
        public void Test_Under1_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 0;
            string expectedMonth = "Ugyldigt tal. Måned kunne ikke bestemmes.";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }


        [TestMethod]
        public void Test_Lig1_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 1;
            string expectedMonth = "Januar";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }


        [TestMethod]
        public void Test_Lig2_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 2;
            string expectedMonth = "Februar";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }


        [TestMethod]
        public void Test_Over12_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 13;
            string expectedMonth = "Ugyldigt tal. Måned kunne ikke bestemmes.";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }


        [TestMethod]
        public void Test_Lig12_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 12;
            string expectedMonth = "December";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }


        [TestMethod]
        public void Test_Lig11_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 11;
            string expectedMonth = "November";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }


        [TestMethod]
        public void Test_Mellem1og12_MonthDeterminer()
        {
            //Arrange
            MonthDeterminer monthDeterminer = new MonthDeterminer();

            int monthNumber = 6;
            string expectedMonth = "Juni";

            //Act
            string actualMonth = monthDeterminer.DetermineMonth(monthNumber);

            //Assert
            Assert.AreEqual(expectedMonth, actualMonth);
        }

        #endregion


        #region LargestNumberFinder

        [TestMethod]
        public void Test_NumberTooSmall_LargestNumberFinder()
        {
            //Arrange
            LargestNumberFinder largestNumberFinder = new LargestNumberFinder();

            int[] numbers = new int[] { 3, 5, 6, 4, 2, 8, 9 };

            int expectedNumber = 2;


            //Act
            int actualNumber = largestNumberFinder.FindLargestNumber(numbers);


            //Assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }


        [TestMethod]
        public void Test_NumberNotInArray_LargestNumberFinder()
        {
            //Arrange
            LargestNumberFinder largestNumberFinder = new LargestNumberFinder();

            int[] numbers = new int[] { 3, 5, 6, 4, 2, 8, 9 };

            int expectedNumber = 0;


            //Act
            int actualNumber = largestNumberFinder.FindLargestNumber(numbers);


            //Assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }


        [TestMethod]
        public void Test_NumberCorrect_LargestNumberFinder()
        {
            //Arrange
            LargestNumberFinder largestNumberFinder = new LargestNumberFinder();

            int[] numbers = new int[] { 3, 5, 6, 4, 2, 8, 9 };

            int expectedNumber = 9;


            //Act
            int actualNumber = largestNumberFinder.FindLargestNumber(numbers);


            //Assert
            Assert.AreEqual(expectedNumber, actualNumber);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_Exception_LargestNumberFinder()
        {
            //Arrange
            LargestNumberFinder largestNumberFinder = new LargestNumberFinder();

            int[] numbers = new int[] { };


            //Act
            int actualNumber = largestNumberFinder.FindLargestNumber(numbers);
        }

        #endregion
    }
}
