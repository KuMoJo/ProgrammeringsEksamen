using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterTheGame
{
    interface IFighter
    {
        /// <summary>
        /// Bruges til at hente eller sætte en fighters liv
        /// </summary>
        int Health { get; set; }
        
        /// <summary>
        /// Benyttes til at udregne hvor meget skade en fighter gør pr. angreb.
        /// Skaden vælges tilfældigt imellem 0 - 10;
        /// </summary>
        /// <returns>returnere et tilfældigt tal imellem 0 og 10</returns>
        int CalcDamage();
        
        /// <summary>
        /// Trækker skaden fra fighterens aktuelle livpoint.
        /// Hvis health < 0 skal fighteren markeres som værende død
        /// </summary>
        /// <param name="dmg">Angiver skaden som fighteren bliver ramt med.</param>
        void TakeDamage(int dmg);
        
        /// <summary>
        /// Bestemmer hvorvidt en fighter er dø eller levende
        /// </summary>
        /// <returns></returns>
        bool IsDead();
    }
}
