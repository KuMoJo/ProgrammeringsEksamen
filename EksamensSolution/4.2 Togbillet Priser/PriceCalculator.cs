using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._2_Togbillet_Priser
{
    /// <summary>
    /// Bruges til at udregne togpriser.
    /// </summary>
    public class PriceCalculator
    {
        /// <summary>
        /// Udregner billetpris baseret på alder.
        /// </summary>
        /// <param name="age"></param>
        public int CalculatePrice(int age)
        {
            int price = -1;

            //Fra 0 til 1 år.
            if (age >= 0 && age <= 1)
            {
                price = 0;
            }

            else if (age >= 2 && age <= 14)
            {
                price = 10;
            }

            else if (age >= 15 && age <= 64)
            {
                price = 20;
            }

            else if (age >= 65)
            {
                price = 5;
            }

            else
            {
                price = -1;
            }

            return price;
        }
    }
}
