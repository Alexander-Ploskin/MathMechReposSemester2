namespace UniqueList
{
    /// <summary>
    /// List without same values
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Adds new value to unique list
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

        /// <summary>
        /// Sets new value to unique list
        /// </summary>
        /// <param name="position">Position of element</param>
        /// <param name="newValue">New value</param>
        public override void SetValueOnPosition(int position, int newValue)
        {
            if (Contains(newValue))
            {
                throw new AdditionOfContainedElementException();
            }

            base.SetValueOnPosition(position, newValue);
        }

    }
}
