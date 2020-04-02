using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleGame;

namespace ConsoleGameTests
{
    [TestClass]
    public class GameMapTests
    {
        private GameMap map = null;

        [TestInitialize]
        public void Initialize()
        {
            map = new GameMap(Environment.CurrentDirectory + @"\Maps\Map2.txt");
        }

        [TestMethod]
        public void MoveToLeftTest()
        {
            
        }
    }
}
