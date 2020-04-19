using NUnit.Framework;
using System;

namespace ConsoleGameTests
{
    using ConsoleGame;

    public class GameMapTests
    {
        private Game game;
        private GameMap map;

        [SetUp]
        public void Initialize()
        {
            map = new GameMap(Environment.CurrentDirectory.TrimEnd(@"\ConsoleGameTests\bin\Debug\netcoreapp3.1".ToCharArray()) + @"\Maps\Map1.txt");
        }

        [Test]
        public void InitializationTest()
        {
            Assert.AreEqual(map.GetToken(), '@');
        }

        [Test]
        public void MoveLeftTest()
        {
            map.GoLeft();
            Assert.AreEqual(map.GetToken(), '@');
        }

        [Test]
        public void MoveRightTest()
        {
            map.GoRight();
            Assert.AreEqual(map.GetToken(), '@');
        }

        [Test]
        public void MoveUpTest()
        {
            map.GoUp();
            Assert.AreEqual(map.GetToken(), '@');
        }

        [Test]
        public void MoveDownTest()
        {
            map.GoDown();
            Assert.AreEqual(map.GetToken(), '@');
        }
    }
}