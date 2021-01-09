using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3_Quick_Sortering
{
    /// <summary>
    /// Bruges til at sortere en liste ved brug af quicksort.
    /// </summary>
    public class QuickSorter
    {
        public List<int> QuickSort(List<int> list)
        {
            //Hvis der er 0 eller 1 elementer er listen allerede sorteret.
            //Gælder især når man kører QuickSort på beforePivot og afterPivot.
            //Hvis beforePivot var tom eller havde én plads, så skal der ikke sorteres mere på,
            //værdier der kommer før pivot.
            //Det samme gælder for afterPivot.
            if (list.Count <= 1)
            {
                return list;
            }

            //Ellers skal den sorteres.
            else
            {
                //Pivot skal være lig den første værdi i listen.
                //Den skal danne midtpunktet for beforePivot og afterPivot.
                //De to lister skal sorteres, så beforePivot har de værdier, som er mindre en pivot,
                //og afterPivot har de værdier, som er højere end pivot.
                int pivot = list[0];

                //Man laver to lister, én for venstre og højre side af pivot.
                List<int> beforePivot = new List<int>();
                List<int> afterPivot = new List<int>();

                //Man gennemgår listen og starter fra 2. plads (1).
                for (int i = 1; i < list.Count; i++)
                {
                    //Man sammenligner den nuværende plads med pivot.
                    //Er pivot større?
                    if (list[i] < pivot)
                    {
                        //Hvis pivot er større, så skal værdien stå på venstre side (under/før) pivot.
                        beforePivot.Add(list[i]);
                    }

                    //Hvis pivot er mindre.
                    else
                    {
                        //Så skal værdien stå på højre side (over/efter) pivot.
                        afterPivot.Add(list[i]);
                    }
                }

                //Man laver nu en liste som skal være den sorterede liste.
                List<int> sortedList = new List<int>();

                //Herunder køres metoden rekursivt indtil alt er sorteret.
                //Listerne opdeles og sorteres indtil de ikke kan opdeles og sorteres længere.

                //Tjek om beforePivot er sorteret, hvis ikke skal den sorteres.
                sortedList.AddRange(QuickSort(beforePivot));
                //Tilføj pivot midt i den sorterede liste.
                //(Altså mellem de værdier der er højere og mindre end pivot).
                sortedList.Add(pivot);
                //Tjek nu om afterPivot skal sorteres.
                sortedList.AddRange(QuickSort(afterPivot));

                //Når der ikke kan sorteres mere returneres den sorterede liste.
                return sortedList;
            }
        }
    }
}
