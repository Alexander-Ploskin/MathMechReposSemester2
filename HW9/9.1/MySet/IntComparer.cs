using System;
using System.Collections.Generic;
using System.Text;

namespace MySet
{
    /// <summary>
    /// My coparer of integer numbers
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        /// <summary>
        /// Compare two integers
        /// </summary>
        /// <param name="item1">First number</param>
        /// <param name="item2">Second number</param>
        /// <returns>1 if first number more, 0 is number 1 is equal to number 2, else -1 </returns>
        public int Compare(int item1, int item2) => item1 > item2 ? 1 : item1 == item2 ? 0 : -1;

    }
}
