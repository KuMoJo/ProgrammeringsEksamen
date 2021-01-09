using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3._2_Quick_Sortering_Optimeret
{
    /// <summary>
    /// En optimeret version af QuickSort som kan sortere en liste.
    /// </summary>
    class QuickSorterOptimized
    {
        /// <summary>
        /// Deler et array i partitions.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int Partition(int[] array, int left, int right)
        {
            //Et punkt som man kan sammenligne left og right med.
            int pivot;
            //Starter i helt venstre side.
            pivot = array[left];

            while (true)
            {
                //Hvis left er mindre en pivot.
                //Første gang vil de altid være ens.
                while (array[left] < pivot)
                {
                    left++;
                }

                //Hvis left er mindre en pivot.
                //Første gang vil de altid være ens.
                while (array[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = array[right];
                    array[right] = array[left];
                    array[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
        public void quickSort(int[] array, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(array, left, right);
                if (pivot > 1)
                {
                    quickSort(array, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(array, pivot + 1, right);
                }
            }
        }

        //public int Partition2(int[] array)
        //{
        //    //Venstre side af listen.
        //    int left = array[0];
        //    //Højre side af listen.
        //    int right = array[array.Length - 1];

        //    //Finder midtpunktet og ned til nærmeste int.
        //    int pivotIndex = Convert.ToInt32(Math.Floor((double)array.Length / 2));
        //    //int pivotIndex = list[Convert.ToInt32(Math.Floor((double)list.Count/ 2))];
        //    //Tilføj pivots værdi.
        //    int pivotValue = array[pivotIndex];

        //    //Byt om på pivot/midten og højre side af listen.
        //    int tmp = array[pivotIndex];
        //    array[pivotIndex] = array[right];
        //    array[right] = tmp;

        //    //Gem værdien på venstre side af listen.
        //    int storedIndex = array[left];

        //    for (int i = 1; i < array.le; i++)
        //    {
        //        //Er den nuværende værdi (i) mindre end pivotValue?
        //        if (array[i] < pivotValue)
        //        {
        //            //Hvis ja, byt rundt på dem.
        //            tmp = array[i];
        //            array[i] = storedIndex;
        //            array[left] = tmp;

        //            //Ryk storedIndex 1 frem i listen.
        //            storedIndex = storedIndex + 1;
        //        }
        //    }

        //    //Byt rundt på storedIndex og right på listen.
        //    //Dette er pivots endelige placering.
        //    tmp = storedIndex;
        //    storedIndex = array[right];
        //    array[right] = tmp;

        //    return storedIndex;
        //}
    }
}
