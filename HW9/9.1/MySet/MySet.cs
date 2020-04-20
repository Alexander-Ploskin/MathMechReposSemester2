using System;
using System.Collections.Generic;
using System.Text;

namespace MySet
{
    class MySet<T> : ISet<T>
    {
        public int Count { get; }
        public bool IsReadOnly { get; }

        private class TreeElement
        {
            public TreeElement(TreeElement parent, T value)
            {
                Value = value;
                Parent = parent;
            }

            public T Value { get; }
            public TreeElement LeftChild { get; set; }
            public TreeElement RightChild { get; set; }
            public TreeElement Parent { get; set; }
        } 


    }
}
