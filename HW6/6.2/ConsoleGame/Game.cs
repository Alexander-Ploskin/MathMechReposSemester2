using System;

namespace ConsoleGame
{
    /// <summary>
    /// This class implements console game
    /// </summary>
    public class Game
    {
        private GameMap map;

        /// <summary>
        /// Only for testing
        /// </summary>
        /// <param name="map">Initializated game map</param>
        public Game(GameMap map)
        {
            this.map = map;
            SetCursor();
        }

        public Game(string path)
        {
            map = new GameMap(path);
            SetCursor();
        }

        /// <summary>
        /// Sets cursor of console
        /// </summary>
        private void SetCursor()
        {
            Console.CursorLeft = map.LeftPosition;
            Console.CursorTop = map.TopPosition;
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Makes game tuen
        /// </summary>
        /// <param name="turnOnMap">Action on the map</param>
        /// <param name="turnOnConsole">Action on the console</param>
        private void MakeTurn(Action turnOnMap, Action turnOnConsole)
        {
            try
            {
                turnOnMap();
                Console.Write(' ');
                Console.CursorLeft--;
                turnOnConsole();
                Console.Write('@');
                Console.CursorLeft--;
            }
            catch (MoveException)
            {
                Console.Beep();
            }
            catch (IndexOutOfRangeException)
            {
                Console.Beep();
            }
        }

        /// <summary>
        /// Tries to move @ left
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnLeft(object sender, EventArgs args) => MakeTurn(() => map.GoLeft(), () => Console.CursorLeft--);

        /// <summary>
        /// Tries to move @ right
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnRight(object sender, EventArgs args) => MakeTurn(() => map.GoRight(), () => Console.CursorLeft++);

        /// <summary>
        /// Tries to move @ down
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnDown(object sender, EventArgs args) => MakeTurn(() => map.GoDown(), () => Console.CursorTop++);

        /// <summary>
        /// Tries to move @ up
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnUp(object sender, EventArgs args) => MakeTurn(() => map.GoUp(), () => Console.CursorTop--);

    }
}
