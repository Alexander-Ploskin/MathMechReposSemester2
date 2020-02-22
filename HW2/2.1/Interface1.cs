using System;

namespace Task1_2
{
    interface IList
    {

        void Add(int value);

        void Remove(int position);

        void Print();

        bool isEmpty();

        int Length();
    }
}
