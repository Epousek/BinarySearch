using System;
using System.Diagnostics;

namespace BinarySearch
{
    class Program
    {
        private static int recursionDepth;
        private static int[] randArray = new int[1000000];
        private static Random rand = new Random();
        private static Stopwatch sw = new Stopwatch();

        static void Main(string[] args)
        {
            bool cont;
            do
            {
                recursionDepth = 0;
                int numToFind = rand.Next(0, randArray.Length * 2);
                FillArray(randArray);

                int resultIndex = Search(numToFind, 0, randArray.Length - 1, randArray);

                if(resultIndex != -1)
                {
                    Console.WriteLine("Podle binárního hledáni se číslo nachází na: " + resultIndex);
                    Console.WriteLine("Podle Array.IndexOf() se číslo nachází na: " + Array.IndexOf(randArray, numToFind));
                }
                else
                {
                    Console.WriteLine("Číslo se v poli nenachází.");
                }
                Console.WriteLine("Binární hledání trvalo " + sw.ElapsedTicks);
                Console.WriteLine("Hloubka rekurze: " + recursionDepth);

                sw.Restart();
                Array.IndexOf(randArray, numToFind);
                sw.Stop();
                Console.WriteLine("IndexOf trval: " + sw.ElapsedTicks);

                cont = Console.ReadKey().Key == ConsoleKey.Enter;
            } while (cont);

        }

        private static int Search(int intToSearch, int start, int end, int[] intArr)
        {
            recursionDepth++;
            sw.Restart();
            if (end < start)
                return -1;
            int middleOfArr = (end + start) / 2;
            if (intToSearch == intArr[middleOfArr])
            {
                sw.Stop();
                return middleOfArr;
            }
            else if (intToSearch < intArr[middleOfArr])
                return Search(intToSearch, start, middleOfArr - 1, intArr);
            else
                return Search(intToSearch, middleOfArr + 1, end, intArr);
        }

        private static void FillArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(0, arr.Length * 2);
            }
            Array.Sort(arr);
        }
    }
}
