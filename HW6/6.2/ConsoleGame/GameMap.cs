using System;
using System.IO;

namespace ConsoleGame
{
    /// <summary>
    /// Implements map of the game and syncs game process with console
    /// </summary>
    public class GameMap
    {
        private char[][] mapMatrix;
        private int height = 0;

        private (int Left, int Top) CharacterPosition = (0, 0);

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
                    mapMatrix[i] = line.ToCharArray();
                    Console.WriteLine(line);
                }
            }

            SetPosition();
        }

        /// <summary>
        /// Position of the @ on the map
        /// </summary>
        public (int, int) Position { get => (CharacterPosition.Top, CharacterPosition.Left); }

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
                    CharacterPosition.Left++;
                }
                CharacterPosition.Left = 0;
                CharacterPosition.Top++;
            }
        }

        /// <summary>
        /// Gets token on this position
        /// </summary>
        /// <returns>Token</returns>
        public char GetToken() => mapMatrix[CharacterPosition.Top][CharacterPosition.Left];

        /// <summary>
        /// Sets new symbol to the position
        /// </summary>
        private void SetSymbol(char newSymbol) => mapMatrix[CharacterPosition.Top][CharacterPosition.Left] = newSymbol;

        /// <summary>
        /// Make turn of the game
        /// </summary>
        /// <param name="changePosition">Action, that changes position of the character</param>
        /// <param name="doInCaseOfWall">Reverse action</param>
        private void Go(Action changePosition)
        {
            try
            {
                SetSymbol(' ');
                var positionBeforeMove = CharacterPosition;
                changePosition();
                if (mapMatrix[CharacterPosition.Top][CharacterPosition.Left] == '■')
                {
                    CharacterPosition = positionBeforeMove;
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
        public void GoRight() => Go(() => CharacterPosition.Left++);

        /// <summary>
        /// Move @ left
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoLeft() => Go(() => CharacterPosition.Left--);

        /// <summary>
        /// Move @ up
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoUp() => Go(() => CharacterPosition.Top--);

        /// <summary>
        /// Move @ down
        /// </summary>
        /// <exception cref="MoveException">Throws when user tries to move aboard map</exception>
        public void GoDown() => Go(() => CharacterPosition.Top++);

    }
}
