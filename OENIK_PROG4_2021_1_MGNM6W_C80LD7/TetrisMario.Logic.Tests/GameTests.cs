// <copyright file="GameTests.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Logic.Tests
{
    using Moq;
    using NUnit.Framework;
    using TetrisMario.Model;
    using static TetrisMario.Model.Enumerators;

    /// <summary>
    /// Logic tests.
    /// </summary>
    [TestFixture]
    public class GameTests
    {
        private GameLogic logic;
        private Player testPlayer;
        private GameModel gameModel;
        private GameItem gameItem;

        /// <summary>
        /// Gets or sets the mocked game item.
        /// </summary>
        public Mock<IGameItem> MockedGameItem { get; set; }

        /// <summary>
        /// SetUp method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.gameModel = new GameModel(20, 20);
            this.gameItem = new GameItem();

            this.MockedGameItem = new Mock<IGameItem>();

            this.logic = new GameLogic(this.gameModel);

            this.testPlayer = new Player(10, 10);
        }

        /// <summary>
        /// Testing check that last layer is full or not.
        /// </summary>
        [Test]
        public void CheckIfBottomIsFullTest()
        {
            GameModel.Map = new GameItem[26, 16];

            GameModel.Map[0, GameModel.Map.GetLength(1) - 2] = null;
            bool firstResult = this.logic.CheckIfBottomIsFull();

            GameModel.Map[1, GameModel.Map.GetLength(1) - 2] = new GameItem();
            GameModel.Map[1, GameModel.Map.GetLength(1) - 2].Type = Types.Player;
            bool secondResult = this.logic.CheckIfBottomIsFull();

            Assert.False(firstResult);
            Assert.False(secondResult);
        }

        /// <summary>
        /// Test for the shoot method.
        /// </summary>
        [Test]
        public void ShootTest()
        {
            Player testPlayer = new Player(10, 10);
            GameModel.Map[testPlayer.X, testPlayer.Y - 1] = null;

            bool result = GameLogic.Shoot(testPlayer);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Checks if players life was decreased in update method.
        /// </summary>
        [Test]
        public void CheckIfLifeDecreased()
        {
            int life = 2;
            GameModel.Map = new GameItem[26, 16];

            GameObject item = new GameObject(Types.Block, 10, 10);
            GameModel.Map[10, 10] = item;

            GameObject nextItem = new GameObject(Types.Player, 10, 11);
            GameModel.Map[10, 11] = nextItem;

            this.logic.Update();

            Assert.AreNotEqual(GameModel.PlayerLife, life);
        }

        /// <summary>
        /// Checks whether the block falls even if it has support.
        /// </summary>
        [Test]
        public void BlockShouldNotFallTest()
        {
            GameObject item = new GameObject(Types.Block, 13, 14);
            GameModel.Map[13, 14] = item;

            this.logic.Update();

            Assert.That(GameModel.Map[item.X, item.Y] != null);
        }

        /// <summary>
        /// Checks if the game of works properly.
        /// </summary>
        [Test]
        public void GameIsOverTest()
        {
            GameModel.PlayerLife = 1;
            this.gameModel.GameOver = false;
            GameModel.Map = new GameItem[26, 16];

            GameObject item = new GameObject(Types.Block, 10, 10);
            GameModel.Map[10, 10] = item;

            GameObject nextItem = new GameObject(Types.Player, 10, 11);
            GameModel.Map[10, 11] = nextItem;

            this.logic.Update();

            Assert.IsTrue(this.gameModel.GameOver);
        }
    }
}
