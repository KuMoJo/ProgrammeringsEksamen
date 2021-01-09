using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTheGame
{
    /// <summary>
    /// Kan simulere to Fighters der kæmper mod hinanden.
    /// </summary>
    public class Fighter : IFighter
    {
        public int Health { get; set; } = 15;
        public string Name { get; private set; }


        public Fighter(string name)
        {
            Name = name;
        }


        public int CalcDamage()
        {
            Random random = new Random();
            int damage = random.Next(1, 6);

            return damage;
        }

        public bool IsDead()
        {
            bool isDead = false;

            if (Health <= 0)
            {
                isDead = true;
            }

            return isDead;
        }

        public void TakeDamage(int dmg)
        {
            Health -= dmg;
        }


        /// <summary>
        /// Fighter tager en tur mod den anden fighter.
        /// </summary>
        /// <param name="otherFighter"></param>
        public void TakeTurn(Fighter otherFighter)
        {
            int damage = CalcDamage();
            otherFighter.TakeDamage(damage);

            Console.WriteLine($"{otherFighter.Name} takes {damage} damage!");

            //Sørger for at health bliver vist som 0 og ikke f.eks. -4.
            if (otherFighter.Health < 0)
            {
                otherFighter.Health = 0;
            }

            Console.WriteLine($"{otherFighter.Name} has {otherFighter.Health} health left.");

            //Console.ReadLine();
        }
    }
}
