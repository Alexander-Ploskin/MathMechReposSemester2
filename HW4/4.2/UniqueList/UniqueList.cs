using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (position < 0)
            {
                throw new Exception("Position can't be negative");
            }

            size++;

            if (position == 0)
            {
                if (head == null)
                {
                    head = new ListElement(value, null);
                    return;
                }

                head = new ListElement(value, head);
                return;
            }

            var currentElement = head;
            for (int i = 0; i < position; ++i)
            {
                if (currentElement == null)
                {
                    throw new Exception("There are not that position");
                }
            }

            currentElement.next = new ListElement(value, currentElement.next);
        }

    }
}
