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
        }

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
                map.GoLeft();
                if (map.GetToken() != '■')
                {
                    map.GoRight();
                    map.SetToken(' ');
                    map.GoLeft();
                    map.SetToken('@');
                }
                else
                {
                    map.GoRight();
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
                map.GoRight();
                if (map.GetToken() != '■')
                {
                    map.GoLeft();
                    map.SetToken(' ');
                    map.GoRight();
                    map.SetToken('@');
                }
                else
                {
                    map.GoLeft();
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
                map.GoDown();
                if (map.GetToken() != '■')
                {
                    map.GoUp();
                    map.SetToken(' ');
                    map.GoDown();
                    map.SetToken('@');
                }
                else
                {
                    map.GoUp();
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
                map.GoUp();
                if (map.GetToken() != '■')
                {
                    map.GoDown();
                    map.SetToken(' ');
                    map.GoUp();
                    map.SetToken('@');
                }
                else
                {
                    Console.Beep();
                    map.GoDown();
                }
            }
            catch (MoveException)
            {
                Console.Beep();
            }
        }

    }
}
