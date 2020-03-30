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
                var eventLoop = new EventLoop();
                eventLoop.LeftHandler += game.OnLeft;
                eventLoop.RightHandler += game.OnRight;
                eventLoop.DownHandler += game.OnDown;
                eventLoop.UpHandler += game.OnUp;
                eventLoop.Run();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
