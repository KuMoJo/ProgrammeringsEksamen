using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._3_Find_Maaned
{
    /// <summary>
    /// Lader dig bestemme måneder baseret på tal-input.
    /// </summary>
    public class MonthDeterminer
    {
        /// <summary>
        /// Returnerer en måned baseret på det tal metoden får som parameter.
        /// </summary>
        /// <param name="monthNumber">Et tal der svarer til en måned. F.eks. 12 = December.</param>
        /// <returns></returns>
        public string DetermineMonth(int monthNumber)
        {
            string month = null;

            if (monthNumber >= 1 && monthNumber <= 12)
            {
                switch (monthNumber)
                {
                    case 1:
                        month = "Januar";
                        break;
                    case 2:
                        month = "Februar";
                        break;
                    case 3:
                        month = "Marts";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "Maj";
                        break;
                    case 6:
                        month = "Juni";
                        break;
                    case 7:
                        month = "Juli";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "Oktober";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                }
            }

            else
            {
                month = "Ugyldigt tal. Måned kunne ikke bestemmes.";
            }

            return month;
        }
    }
}
