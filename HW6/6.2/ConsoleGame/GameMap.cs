using System;
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
        public int LeftPosition { get; set; } = 0;
        public int TopPosition { get; set; } = 0;

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
                Array.Resize(ref mapMatrix, height);

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
                    LeftPosition++;
                }
                LeftPosition = 0;
                TopPosition++;
            }
        }

        private void Go(Action changePosition, Action doInCaseOfWall)
        {
            changePosition();
            if (mapMatrix[TopPosition][LeftPosition] == '■')
            {
                doInCaseOfWall();
                throw new MoveException();
            }
        }

        /// <summary>
        /// Move @ right
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoRight() => Go(() => LeftPosition++, () => LeftPosition--);

        /// <summary>
        /// Move @ left
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoLeft() => Go(() => LeftPosition--, () => LeftPosition++);

        /// <summary>
        /// Move @ up
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoUp() => Go(() => TopPosition--, () => TopPosition++);

        /// <summary>
        /// Move @ down
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Throws when user tries to move aboeard map</exception>
        public void GoDown() => Go(() => TopPosition++, () => TopPosition--);

    }
}
