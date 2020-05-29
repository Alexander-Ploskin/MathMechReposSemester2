using System;
using System.Collections.Generic;

namespace GenericBubbleSort
{
    /// <summary>
    /// Functions to working with generic list
    /// </summary>
    /// <typeparam name="T">Type of values in list</typeparam>
    public static class ListFuncs<T>
    {
        /// <summary>
        /// Sorts list with bubble sort algorithm
        /// </summary>
        /// <param name="list">List< you wanna to sort</param>
        /// <param name="comparer">Comparer for values in list</param>
        /// <returns>New sorted list with values from input list</returns>
        public static List<T> BubbleSort(List<T> list, IComparer<T> comparer)
        {
            var helpArray = new T[list.Count];
            list.CopyTo(helpArray);

            for (int i = 0; i < helpArray.Length - 1; ++i)
            {
                for (int j = 0; j < helpArray.Length - i - 1; ++j)
                {
                    if (comparer.Compare(helpArray[j], helpArray[j + 1]) > 0)
                    {
                        var temp = helpArray[j];
                        helpArray[j] = helpArray[j + 1];
                        helpArray[j + 1] = temp;
                    }
                }
            }

            var output = new List<T>();
            foreach (var item in helpArray)
            {
                output.Add(item);
            }

            return output;
        }

        /// <summary>
        /// Prints list on console
        /// </summary>
        /// <param name="list">List to print</param>
        public static void PrintList(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

    }
}
