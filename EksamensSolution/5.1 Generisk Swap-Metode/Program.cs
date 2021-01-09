using _5._1_Generisk_Swap_Metode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1_Generisk_Swap_metode
{
    /// <summary>
    /// Lav en generisk metode som kan ombytte værdityper.
    /// </summary>
    class Program
    {
        static int firstInt = 1;
        static int secondInt = 2;

        static string firstString = "Hello";
        static string secondString = "World";

        static float firstFloat = 1.1f;
        static float secondFloat = 2.2f;

        static char firstChar = 'A';
        static char secondChar = 'B';

        static bool firstBool = true;
        static bool secondBool = false;


        static void Main(string[] args)
        {
            MySwap mySwap = new MySwap();

            Console.WriteLine("Before swap!");


            Console.WriteLine($"First: {firstInt} / Second: {secondInt}");

            Console.WriteLine($"First: {firstString} / Second: {secondString}");

            Console.WriteLine($"First: {firstFloat} / Second: {secondFloat}");

            Console.WriteLine($"First: {firstChar} / Second: {secondChar}");

            Console.WriteLine($"First: {firstBool} / Second: {secondBool}");


            Console.WriteLine("After swap!");


            mySwap.Swap(ref firstInt, ref secondInt);
            Console.WriteLine($"First: {firstInt} / Second: {secondInt}");

            mySwap.Swap(ref firstString, ref secondString);
            Console.WriteLine($"First: {firstString} / Second: {secondString}");

            mySwap.Swap(ref firstFloat, ref secondFloat);
            Console.WriteLine($"First: {firstFloat} / Second: {secondFloat}");

            mySwap.Swap(ref firstChar, ref secondChar);
            Console.WriteLine($"First: {firstChar} / Second: {secondChar}");

            mySwap.Swap(ref firstBool, ref secondBool);
            Console.WriteLine($"First: {firstBool} / Second: {secondBool}");


            Console.ReadLine();
        }
    }
}
