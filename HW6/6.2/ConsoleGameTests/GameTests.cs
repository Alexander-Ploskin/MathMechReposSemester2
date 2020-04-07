using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleGame;

namespace ConsoleGameTests
{
    [TestClass]
    public class GameTests
    {
        private Game game;
        private GameMap map;

        [TestInitialize]
        public void Initialize()
        {
            Console.CursorTop = 100;
            Console.CursorLeft = 100;
            map = new GameMap(Environment.CurrentDirectory.TrimEnd(@"\ConsoleGameTests\bin\Debug".ToCharArray()) + @"\Maps\Map1.txt");
            game = new Game(map);
        }

        [TestMethod]
        public void InitializationTest()
        {
            Assert.AreEqual(map.GetToken(), '@');
        }

        [TestMethod]
        public void MoveLeftTest()
        {
            game.OnLeft(null, EventArgs.Empty);
            Assert.AreEqual(map.GetToken(), '@');
            map.GoRight();
            Assert.AreEqual(map.GetToken(), ' ');
        }

        [TestMethod]
        public void MoveRightTest()
        {
            game.OnRight(null, EventArgs.Empty);
            Assert.AreEqual(map.GetToken(), '@');
            map.GoLeft();
            Assert.AreEqual(map.GetToken(), ' ');
        }

        [TestMethod]
        public void MoveUpTest()
        {
            game.OnUp(null, EventArgs.Empty);
            Assert.AreEqual(map.GetToken(), '@');
            map.GoDown();
            Assert.AreEqual(map.GetToken(), ' ');
        }

        [TestMethod]
        public void MoveDownTest()
        {
            game.OnDown(null, EventArgs.Empty);
            Assert.AreEqual(map.GetToken(), '@');
            map.GoUp();
            Assert.AreEqual(map.GetToken(), ' ');
        }

    }
}
