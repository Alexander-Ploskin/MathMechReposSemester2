using System;

namespace Task2_2
{
    interface IList
    {

        void Add(string value);

        void RemoveByPosition(int position);

        void RemoveByValue(string value);

        void Print();

        bool isEmpty();

        int Length();
    }
}
