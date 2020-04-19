using System;

namespace UniqueList
{
    /// <summary>
    /// List without same values
    /// </summary>
    public class UniqueList: List
    {
        /// <summary>
        /// Ads new value to unique list
        /// </summary>
        /// <param name="value">New value</param>
        /// <param name="position">Position in list</param>
        public override void Add(int value, int position)
        {
            if (Contains(value))
            {
                throw new AdditionOfContainedElementException();
            }

            base.Add(value, position);
        }

    }
}
