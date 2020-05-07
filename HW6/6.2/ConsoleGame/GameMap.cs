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

        /// <summary>
        /// Calculates position of the character
        /// </summary>
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

        /// <summary>
        /// Gets token on this position
        /// </summary>
        /// <returns>Token</returns>
        public char GetToken() => mapMatrix[TopPosition][LeftPosition];

        /// <summary>
        /// Sets new symbol to the position
        /// </summary>
        private void SetSymbol(char newSymbol)
            => mapMatrix[TopPosition] = mapMatrix[TopPosition].Remove(LeftPosition) + newSymbol.ToString() + mapMatrix[TopPosition].Remove(0, LeftPosition + 1);

        /// <summary>
        /// Make turn of the game
        /// </summary>
        /// <param name="changePosition">Action, that changes position of the character</param>
        /// <param name="doInCaseOfWall">Reverse action</param>
        private void Go(Action changePosition, Action doInCaseOfWall)
        {
            try
            {
                SetSymbol(' ');
                changePosition();
                if (mapMatrix[TopPosition][LeftPosition] == '■')
                {
                    doInCaseOfWall();
                    SetSymbol('@');
                    throw new MoveException();
                }
                SetSymbol('@');
            }
            catch (IndexOutOfRangeException)
            {
                throw new MoveException();
            }
        }

        /// <summary>
        /// Move @ right
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoRight() => Go(() => LeftPosition++, () => LeftPosition--);

        /// <summary>
        /// Move @ left
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoLeft() => Go(() => LeftPosition--, () => LeftPosition++);

        /// <summary>
        /// Move @ up
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoUp() => Go(() => TopPosition--, () => TopPosition++);

        /// <summary>
        /// Move @ down
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoDown() => Go(() => TopPosition++, () => TopPosition--);

    }
}
