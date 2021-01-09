using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2_Bubble_Sortering
{
    /// <summary>
    /// Sorterer et array med en bubblesort.
    /// </summary>
    public class BubbleSorter
    {
        public int[] BubbleSort(int[] array)
        {
            bool swapped;

            //Skal altid køres mindst én gang.
            //Se video linket: https://www.youtube.com/watch?v=8t7D6pj3y10
            do
            {
                //Swap er altid false i starten er hver loop.
                //Således ved vi, om array er sorteret.
                //For hvis den stadig er false til sidst,
                //så var der ikke noget som skulle ombyttes (den var sorteret).
                swapped = false;

                //Lav et tjek på hele arrayet, startende fra 2. plads og så mod højre.
                for (int i = 1; i < array.Length; i++)
                {
                    //Hvis den forrige plads' værdi er højere end den nuværende,
                    //skal de swappes.
                    if (array[i - 1] > array[i])
                    {
                        //Her swappes de.
                        int tmp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = tmp;

                        //Og swap bliver sat til true.
                        swapped = true;
                    }
                }

                //Så længe swapped er true skal den køre igen.
                //Når swap er false er der ikke længere nogen elementer som er blevet byttet.
                //Array er da sorteret.
                //Den skal da altid køre igennem én ekstra gang efter sortering for at vi kan være sikre på,
                //at arrayet er swapped.
            } while (swapped == true);

            //Nu kan man return det sorterede array.
            return array;
        }
    }
}
