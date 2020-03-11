using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueList
{
    class UniqueList: List
    {
        public override void Add(string value)
        {
            if (Contains(value))
            {
                throw new AdditionOfContainedElementException();
            }

            if (Empty())
            {
                head = new ListElement(value, null);
            }

            head = new ListElement(value, head.next);
            size++;
        }
    }
}
