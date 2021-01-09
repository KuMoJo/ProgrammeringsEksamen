using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._4_Highscore_Sortering
{
    /// <summary>
    /// Implementer en Highscore-klasse som kan sortes med navn og score ved brug af generisk IComparable.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<Highscore> list = new List<Highscore>
            {
                new Highscore("Henrik", 800),
                new Highscore("Signe", 1000),
                new Highscore("Stinna", 0)
            };


            //list = list.Take(3).ToList();
            list.Sort();


            foreach (Highscore highscore in list)
            {
                Console.WriteLine(highscore);
            }

            Console.ReadLine();
        }
    }
}
