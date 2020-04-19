﻿using System;
using System.IO;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var game = new Game(Environment.CurrentDirectory.TrimEnd(@"\ConsoleGame\bin\Debugnetcoreapp3.1".ToCharArray()) + @"\Maps\Map2.txt");
                var eventLoop = new EventLoop();
                eventLoop.LeftHandler += game.OnLeft;
                eventLoop.RightHandler += game.OnRight;
                eventLoop.DownHandler += game.OnDown;
                eventLoop.UpHandler += game.OnUp;
                eventLoop.Run();
            }
            catch (IOException)
            {
                Console.WriteLine("Invalid path or map file");
            }
        }

    }
}