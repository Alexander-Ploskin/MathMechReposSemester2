using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            Console.WriteLine("Enter the path of map file:");
            path = Console.ReadLine();

            try
            {
                var game = new Game(path);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
