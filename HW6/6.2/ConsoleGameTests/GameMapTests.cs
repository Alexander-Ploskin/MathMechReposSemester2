using NUnit.Framework;
using System;

namespace ConsoleGameTests
{
    using ConsoleGame;
    using System.Collections.Generic;

    public class GameMapTests
    {
        private static GameMap map;

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

        private static IEnumerable<Action> Moves()
        {
            yield return () => map.GoDown();
            yield return () => map.GoLeft();
            yield return () => map.GoRight();
            yield return () => map.GoUp();
        }

        private static IEnumerable<(Action, Action)> DoubleMoves()
        {
            yield return (() => map.GoDown(), () => map.GoRight());
            yield return (() => map.GoDown(), () => map.GoLeft());
            yield return (() => map.GoRight(), () => map.GoUp());
            yield return (() => map.GoRight(), () => map.GoDown());
        }

        [TestCaseSource("Moves")]
        public void MoveToTheWhiteSpaceTest(Action move)
        {
            move();
            Assert.AreEqual(map.GetToken(), '@');
        }

        [TestCaseSource("Moves")]
        public void MoveToTheWallTest(Action move)
        {
            move();
            Assert.Throws<MoveException>(() => move());
        }

        [TestCaseSource("DoubleMoves")]
        public void MoveAboardTheMapTest((Action firstMove, Action secondMove) moves)
        {
            moves.firstMove();
            moves.secondMove();
            moves.secondMove();
            Assert.Throws<MoveException>(() => moves.secondMove());
        }
    }
}