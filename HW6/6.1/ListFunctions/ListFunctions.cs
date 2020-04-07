using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFunctions
{
    /// <summary>
    /// Class implements three functions for List<int>
    /// </summary>
    public static class ListFunctions
    {
        /// <summary>
        /// Aplicates func to all elements of list
        /// </summary>
        /// <param name="list">Input list</param>
        /// <param name="func">Int function for elements</param>
        /// <returns>List of transformed elements</returns>
        public static List<int> Map(List<int> list,Func<int, int> func)
        {
            var output = new List<int>();

            foreach (int item in list)
            {
                output.Add(func(item));
            }

            return output;
        }

        /// <summary>
        /// Create list, that has only elements, that fulfill the condition
        /// </summary>
        /// <param name="list">Input list</param>
        /// <param name="func">Bool func that filtres list</param>
        /// <returns>List of desired elements</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> func)
        {
            foreach (int item in list)
            {
                if (func(item))
                {
                    list.Remove(item);
                }
            }

            return list;
        }

        /// <summary>
        /// Aplicates func for all elements and calculate number
        /// </summary>
        /// <param name="list">Input list</param>
        /// <param name="counter">Var that accumulates number</param>
        /// <param name="func">Func that aplicates for all elements</param>
        /// <returns>Number, that was calculated</returns>
        public static int Fold(List<int> list, int counter, Func<int, int, int> func)
        {
            foreach (int item in list)
            {
                counter = func(counter, item);
            }

            return counter;
        }

    }
}
