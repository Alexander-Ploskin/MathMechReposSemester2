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
        private int[] position = new int[2]{ 0, 0 };

        /// <summary>
        /// Initializes game map and outputs to console 
        /// </summary>
        /// <param name="path">Path to the map</param>
        public GameMap(string path)
        {
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

            SetCursor();
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Sets cursor and position in mapMatrix during initialization
        /// </summary>
        private void SetCursor()
        {
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < mapMatrix[i].Length; ++j)
                {
                    if (mapMatrix[i][j] == '@')
                    {
                        Console.CursorLeft += j;
                        Console.CursorTop -= height - i;
                        position[0] = i;
                        position[1] = j;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Gets token from map matrix
        /// </summary>
        /// <returns>Token in map matrix in current position</returns>
        public char GetToken() => mapMatrix[position[0]][position[1]];

        /// <summary>
        /// Move @ right
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoRight()
        {
            Console.CursorLeft++;
            position[1]++;
        }

        /// <summary>
        /// Move @ left
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoLeft()
        {
            Console.CursorLeft--;
            position[1]--;
        }

        /// <summary>
        /// Move @ up
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoUp()
        {
            Console.CursorTop--;
            position[0]--;
        }

        /// <summary>
        /// Move @ down
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoDown()
        {
            Console.CursorTop++;
            position[0]++;
        }
        
        /// <summary>
        /// Changes symbol in position
        /// </summary>
        /// <param name="newToken">New symbol</param>
        /// <returns>new string</returns>
        private string CreateStringWithNewToken(char newToken)
        {
            var newString = "";
            for (int i = 0; i < mapMatrix[position[0]].Length; ++i)
            {
                if (i != position[1])
                {
                    newString += mapMatrix[position[0]][i];
                    continue;
                }
                newString += newToken;
            }
            return newString;
        }

        /// <summary>
        /// sets new symbol in position
        /// </summary>
        /// <param name="newToken">New symbol</param>
        public void SetToken(char newToken)
        {
            mapMatrix[position[0]] = CreateStringWithNewToken(newToken);
            Console.Write($"{newToken}");
            Console.CursorLeft--;
        }

    }
}
