using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            FightManager fightManager = new FightManager();

            Fighter fighter1 = new Fighter("Fighter 1");
            Fighter fighter2 = new Fighter("Figher 2");

            //De kæmper så længe ingen af dem er døde.
            while (!fighter1.IsDead() && !fighter2.IsDead())
            {
                //Til at tilfældigt bestemme hvem der starter denne runde.
                Random random = new Random();
                int randomNumber = random.Next(1, 3);

                fightManager.Fight(fighter1, fighter2, randomNumber);
            }

            Console.ReadLine();
        }
    }
}
