using System;

namespace Task2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var myTable = new HashTable();

            myTable.Add("Rabbit");
            myTable.Add("Elephant");
            myTable.Add("Wolf");
            myTable.Add("Horse");
            myTable.Add("Pig");
            myTable.Add("Cow");
            Console.WriteLine(!myTable.Contains("Cat"));
            Console.WriteLine(myTable.Contains("Pig"));
            myTable.Remove("Pig");
            Console.WriteLine(!myTable.Contains("Pig"));
        }
    }
}