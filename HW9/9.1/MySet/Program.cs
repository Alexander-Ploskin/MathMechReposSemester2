using System;

namespace MySet
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new MySet<int>(new IntComparer()) { 1, 2, 5, -10, -14 };
            set.Add(-14);
            set.Add(-12);
            set.Add(3);
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}
