using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleGame
{
    /// <summary>
    /// Implements map of the game and syncs game process with console
    /// </summary>
    public class GameMap
    {
        private string[] mapMatrix;
        private int height = 0;
        public int[] position { get; set; }

        /// <summary>
        /// Initializes game map and outputs to console 
        /// </summary>
        /// <param name="path">Path to the map</param>
        public GameMap(string path)
        {
            position = new int[2] { 0, 0 };
            using (var sr = new StreamReader(path))
            {
                if (!int.TryParse(sr.ReadLine(), out height))
                {
                    throw new IOException("Invalid map file");
                }
                Array.Resize<string>(ref mapMatrix, height);

                for (int i = 0; i < height; ++i)
                {
                    var line = sr.ReadLine();
                    mapMatrix[i] = line;
                    Console.WriteLine(line);
                }
            }

            SetPosition();
        }

        private void SetPosition()
        {
            for (int i = 0; i < mapMatrix.Length; ++i)
            {
                for (int j = 0; j < mapMatrix[i].Length; ++j)
                {
                    if (mapMatrix[i][j] == '@')
                    {
                        return;
                    }
                    position[0]++;
                }
                position[0] = 0;
                position[1]++;
            }
        }

        /// <summary>
        /// Move @ right
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoRight()
        {
            position[1]++;
            if (mapMatrix[position[0]][position[1]] == '■')
            {
                position[1]--;
                throw new MoveException();
            }
        }

        /// <summary>
        /// Move @ left
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoLeft()
        {
            position[1]--;
            if (mapMatrix[position[0]][position[1]] == '■')
            {
                position[1]++;
                throw new MoveException();
            }
        }

        /// <summary>
        /// Move @ up
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoUp()
        {
            position[0]--;
            if (mapMatrix[position[0]][position[1]] == '■')
            {
                position[0]++;
                throw new MoveException();
            }
        }

        /// <summary>
        /// Move @ down
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoDown()
        {
            position[0]++;
            if (mapMatrix[position[0]][position[1]] == '■')
            {
                position[0]--;
                throw new MoveException();
            }
        }

    }
}
