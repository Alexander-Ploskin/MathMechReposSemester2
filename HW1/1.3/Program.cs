using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        private static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        int t = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = t;
                    }
                }
            }
        }

        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write($"{array[i]} ");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Fill the array:");
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            BubbleSort(array);
            Console.WriteLine("Sorted array:");
            PrintArray(array);
        }

    }
}