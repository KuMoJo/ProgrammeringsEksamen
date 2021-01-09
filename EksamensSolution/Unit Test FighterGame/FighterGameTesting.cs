using System;
using FighterTheGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Test_FighterGame
{
    [TestClass]
    public class FighterGameTesting
    {
        #region Fighter

        [TestMethod]
        public void Test_True_IsDead_Fighter()
        {
            //Arrange
            Fighter fighter1 = new Fighter("Fighter 1");

            fighter1.Health = 0;

            bool expected = true;


            //Act
            bool actual = fighter1.IsDead();


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_False_IsDead_Fighter()
        {
            //Arrange
            Fighter fighter1 = new Fighter("Fighter 1");

            bool expected = false;


            //Act
            bool actual = fighter1.IsDead();


            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_TakeDamage_Fighter()
        {
            //Arrange
            Fighter fighter1 = new Fighter("Fighter 1");

            int expected = 10;


            //Act
            fighter1.TakeDamage(5);
            int actual = fighter1.Health;


            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_HealthUnder0_TakeTurn_Fighter()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            int expected = 0;


            //Act
            fighter2.Health = -4;

            fighter1.TakeTurn(fighter2);

            int actual = fighter2.Health;


            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region FightManager Fight-method

        [TestMethod]
        public void Test_Number1_Fight_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            string expected = $"{fighter1.Name} started.";


            //Act
            string actual = fightManager.Fight(fighter1, fighter2, 1);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Number2_Fight_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            string expected = $"{fighter2.Name} started.";


            //Act
            string actual = fightManager.Fight(fighter1, fighter2, 2);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Number3_Fight_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            string expected = "Something went wrong.";


            //Act
            string actual = fightManager.Fight(fighter1, fighter2, 3);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Number0_Fight_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            string expected = "Something went wrong.";


            //Act
            string actual = fightManager.Fight(fighter1, fighter2, 0);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion


        #region FightManager NextRound-method

        [TestMethod]
        public void Test_False_LastIsDead_False_FirstIsDead_NextRound_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            string expected = "Next round!";


            //Act
            string actual = fightManager.NextRound(fighter1, fighter2);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_False_LastIsDead_True_FirstIsDead_NextRound_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            fighter1.Health = 0;

            string expected = $"{fighter2.Name} won!";


            //Act
            string actual = fightManager.NextRound(fighter1, fighter2);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_True_LastIsDead_NextRound_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            fighter2.Health = 0;

            string expected = $"{fighter1.Name} won!";


            //Act
            string actual = fightManager.NextRound(fighter1, fighter2);


            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_SomethingWentWrong_FightManager()
        {
            //Arrange
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Fighter 2");

            fighter1.Health = 0;
            fighter2.Health = 0;


            //Act
            fightManager.NextRound(fighter1, fighter2);
        }

        #endregion
    }
}
