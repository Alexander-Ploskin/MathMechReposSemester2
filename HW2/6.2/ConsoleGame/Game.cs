using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleGame
{
    class Game
    {
        public Game(string path)
        {
            int downDisplacement = 0;
            int leftDisplacement = 0;

            using (var sr = new StreamReader(path))
            {
                string line = "";
                bool spawned = false;

                while ((line = sr.ReadLine()) != null)
                { 
                    if (!spawned)
                    {
                        leftDisplacement = 0;

                        for (int i = 0; i < line.Length; ++i)
                        {
                            if (line[i] == ' ' && !spawned)
                            {
                                Console.Write('@');
                                spawned = true;
                                i++;
                            }

                            if (!spawned)
                            {
                                leftDisplacement++;
                            }

                            Console.Write(line[i]);
                        }

                        Console.WriteLine();
                        downDisplacement++;
                        continue;
                    }

                    Console.WriteLine(line);
                    downDisplacement++;
                }
            }

            Console.CursorTop -= downDisplacement;
            Console.CursorTop++;
            Console.CursorLeft += leftDisplacement;
        }

        public void OnLeft(object sender, EventArgs args)
        {
            if (Console.CursorLeft == 0)
            {
                return;
            }

            Console.CursorLeft--;
        }

        public void OnRight(object sender, EventArgs args)
        {
            Console.CursorLeft++;
        }

        public void OnDown(object sender, EventArgs args)
        {
            Console.CursorTop++;
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (Console.CursorTop == 0)
            {
                return;
            }
            Console.CursorTop--;
        }

    }
}
