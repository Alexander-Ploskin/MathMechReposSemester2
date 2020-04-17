using System;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new List();

            for (int i = 0; i < 10; ++i)
            {
                myList.Add(i, 0);
            }

            myList.Print();

            myList.Remove(2);
            myList.Remove(6);
            myList.Remove(15);

            myList.Print();

            Console.WriteLine(myList.Length());
        }

    }
}