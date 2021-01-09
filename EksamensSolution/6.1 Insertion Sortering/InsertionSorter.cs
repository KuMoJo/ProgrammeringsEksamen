using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1_Insertion_Sortering
{
    /// <summary>
    /// En klasse der gør det muligt at sortere et array ved brug af insertionsort.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertionSorter
    {
        public int[] InsertionSort(int[] array)
        {
            int value;
            int pointer;

            //Start ved 2. plads (1) i array og gå én op/højre hver gang.
            for (int i = 1; i < array.Length; i++)
            {
                //Nuværende værdi er den nuværende plads på arrayet.
                value = array[i];
                //Pointer er den nuværende plads på arrayet.
                pointer = i;

                //Man starter fra i. Når pointer er 0 er vi ved starten/venstre side af arrayet.
                //Man gennemgår altså arrayet fra højre (ved i) mod venstre (til 0) hver gang.
                //Hvis ikke 0, sammenlign value med den værdi der er på forrige plads.
                //Er den forrige/venstre større?
                while (pointer > 0 && value < array[pointer - 1])
                {
                    //Hvis den er, så rykkes den til venstre ind på den nuværende pointers plads.
                    array[pointer] = array[pointer - 1];
                    //Pointer går én ned. For hvert for-loop kommer while-loop til at køre en ekstra gang.
                    //Således gennemgår man altså altså hele arrayet fra højre mod venstre hvert for-loop.
                    //Se videoen linket: https://www.youtube.com/watch?v=PwgZ_hKMY-4
                    pointer = pointer - 1;
                }

                //Gennem while loopet har man vurderet hvilken plads value skal være på.
                array[pointer] = value;
            }

            //Return når arrayet er gennemgået.
            return array;
        }
    }
}
