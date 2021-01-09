using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1_Generisk_Swap_Metode
{
    public class MySwap
    {
        /// <summary>
        /// Ombytter værdityper.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">Første værditype.</param>
        /// <param name="second">Anden værditype.</param>
        public void Swap<T>(ref T first, ref T second)
        {
            T tmp = first;
            first = second;
            second = tmp;
        }
    }
}
