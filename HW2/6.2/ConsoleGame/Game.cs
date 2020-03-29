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
            using (var sr = new StreamReader(path))
            {
                string line = "";
                bool spawned = false;

                while ((line = sr.ReadLine()) != null)
                { 
                    if (!spawned)
                    {
                        for (int i = 0; i < line.Length; ++i)
                        {
                            if (line[i] == ' ' && !spawned)
                            {
                                Console.Write('@');
                                spawned = true;
                                i++;
                            }
                            Console.Write(line[i]);
                        }
                        Console.WriteLine();
                        continue;
                    }

                    Console.WriteLine(line);
                }
            }
        }
    }
}
