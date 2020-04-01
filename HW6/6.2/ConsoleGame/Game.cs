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
        GameMap map;

        public Game(string path)
        {
            this.map = new GameMap(path);
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
                map.goLeft();
                if (map.getToken() != '■')
                {
                    map.goRight();
                    map.setToken(' ');
                    map.goLeft();
                    map.setToken('@');
                }
                else
                {
                    map.goRight();
                    Console.Beep();
                }
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
                map.goRight();
                if (map.getToken() != '■')
                {
                    map.goLeft();
                    map.setToken(' ');
                    map.goRight();
                    map.setToken('@');
                }
                else
                {
                    map.goLeft();
                    Console.Beep();
                }
            }
            catch (MoveException)
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
                map.goDown();
                if (map.getToken() != '■')
                {
                    map.goUp();
                    map.setToken(' ');
                    map.goDown();
                    map.setToken('@');
                }
                else
                {
                    map.goUp();
                    Console.Beep();
                }
            }
            catch (MoveException)
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
                map.goUp();
                if (map.getToken() != '■')
                {
                    map.goDown();
                    map.setToken(' ');
                    map.goUp();
                    map.setToken('@');
                }
                else
                {
                    Console.Beep();
                    map.goDown();
                }
            }
            catch (MoveException)
            {
                Console.Beep();
            }
        }

    }
}
