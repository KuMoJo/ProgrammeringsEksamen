using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTheGame
{
    /// <summary>
    /// Håndterer en kamp mellem to Fighters.
    /// </summary>
    public class FightManager
    {
        /// <summary>
        /// Håndterer kampen mellem Fighter 1 og 2.
        /// </summary>
        /// <param name="fighter1"></param>
        /// <param name="fighter2"></param>
        public string Fight(Fighter fighter1, Fighter fighter2, int randomNumber)
        {
            //Fighter 1 starts the turn if random number is 1.
            if (randomNumber == 1)
            {
                NextRound(fighter1, fighter2);
                Console.WriteLine();

                return $"{fighter1.Name} started.";
            }

            //Fighter 2 starts the turn if random number is 2.
            else if (randomNumber == 2)
            {
                NextRound(fighter2, fighter1);
                Console.WriteLine();

                return $"{fighter2.Name} started.";
            }

            else
            {
                return "Something went wrong.";
            }
        }


        public string NextRound(Fighter first, Fighter last)
        {
            //Fighter 1 gør et angreb mod 2.
            first.TakeTurn(last);

            //Tjekker om 2 døde. Hvis ikke, så kan 2 gøre et angreb mod 1.
            if (!last.IsDead())
            {
                last.TakeTurn(first);

                //Tjekker om 1 døde efter runden.
                //Laver tjek her for at undgå for mange nested if.
                if (first.IsDead())
                {
                    Console.WriteLine($"{first.Name} was defeated.");
                    Console.WriteLine($"{last.Name} won!");

                    //Console.ReadLine();

                    return $"{last.Name} won!";
                }

                return "Next round!";
            }

            //Tjekker om 2 døde efter runden.
            //Laver tjek her for at undgå for mange nested if.
            else if (last.IsDead() && !first.IsDead())
            {
                Console.WriteLine();
                Console.WriteLine($"{last.Name} was defeated.");
                Console.WriteLine($"{first.Name} won!");

                //Console.ReadLine();

                return $"{first.Name} won!";
            }

            else
            {
                throw new Exception("Something went wrong.");
            }
        }
    }
}
