using System.Collections.Generic;

namespace GenericBubbleSort
{
    /// <summary>
    /// Implementation of IComparer for integers
    /// </summary>
    public class IntComparer : IComparer<int>
    {
        /// <summary>
        /// Compares two integer numbers
        /// </summary>
        /// <param name="firstItem">First number</param>
        /// <param name="secondItem">Second number</param>
        /// <returns>1 if first bigger, 0 if first is equal to second else -1</returns>
        public int Compare(int firstItem, int secondItem) => firstItem == secondItem ? 0 : firstItem > secondItem ? 1 : -1; 
    }
}
