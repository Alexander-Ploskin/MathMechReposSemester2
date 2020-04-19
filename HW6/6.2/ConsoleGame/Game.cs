using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            Console.CursorLeft = map.position[0];
            Console.CursorTop = map.position[1];
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Tries to move @ left
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnLeft(object sender, EventArgs args)
        {
            try
            {
                map.GoLeft();
                Console.Write(' ');
                Console.CursorLeft -= 2;
                Console.Write('@');
                Console.CursorLeft--;
            }
            catch (IndexOutOfRangeException)
            {
                Console.Beep();
            }
            catch (MoveException)
            {
                Console.Beep();
            }
        }

        /// <summary>
        /// Tries to move @ right
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnRight(object sender, EventArgs args)
        {
            try
            {
                map.GoRight();
                Console.Write(' ');
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
        /// Tries to move @ down
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnDown(object sender, EventArgs args)
        {
            try
            {
                map.GoDown();
                Console.Write(' ');
                Console.CursorLeft--;
                Console.CursorTop++;
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
        /// Tries to move @ up
        /// </summary>
        /// <param name="sender">Waits event from keyboard</param>
        /// <param name="args">Empty param</param>
        public void OnUp(object sender, EventArgs args)
        {
            try
            {
                map.GoUp();
                Console.Write(' ');
                Console.CursorLeft--;
                Console.CursorTop--;
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

    }
}
