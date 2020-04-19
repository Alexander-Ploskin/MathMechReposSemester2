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
                Console.CursorLeft--;
                if (map.GetToken() != '■')
                {
                    map.GoRight();
                    Console.CursorLeft++;
                    map.SetToken(' ');
                    map.GoLeft();
                    Console.CursorLeft--;
                    map.SetToken('@');
                }
                else
                {
                    map.GoRight();
                    Console.CursorLeft++;
                    Console.Beep();
                }
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
                Console.CursorLeft++;
                if (map.GetToken() != '■')
                {
                    map.GoLeft();
                    Console.CursorLeft--;
                    map.SetToken(' ');
                    map.GoRight();
                    Console.CursorLeft++;
                    map.SetToken('@');
                }
                else
                {
                    map.GoLeft();
                    Console.CursorLeft--;
                    Console.Beep();
                }
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
                Console.CursorTop++;
                if (map.GetToken() != '■')
                {
                    map.GoUp();
                    Console.CursorTop--;
                    map.SetToken(' ');
                    map.GoDown();
                    Console.CursorTop++;
                    map.SetToken('@');
                }
                else
                {
                    map.GoUp();
                    Console.CursorTop--;
                    Console.Beep();
                }
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
                Console.CursorTop--;
                if (map.GetToken() != '■')
                {
                    map.GoDown();
                    Console.CursorTop++;
                    map.SetToken(' ');
                    map.GoUp();
                    Console.CursorTop--;
                    map.SetToken('@');
                }
                else
                {
                    Console.Beep();
                    map.GoDown();
                    Console.CursorTop++;
                }
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
