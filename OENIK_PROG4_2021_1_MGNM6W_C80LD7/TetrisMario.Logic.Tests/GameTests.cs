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
        private Types types;
        private Directions dir;
        private GameLogic logic;
        private Player testPlayer;
        private GameModel gameModel;
        private GameItem gameItem;
        private Player player;

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

            // this.types = Types.Block;

            this.testPlayer = new Player(10, 10);
        }

        /// <summary>
        /// Test spawn method.
        /// </summary>
        //[Test]
        //public void TestUpdate()
        //{
        //    // Arrange
        //    this.types = Types.Block;
        //    this.dir = Directions.Up;
        //    this.MockedGameItem.Setup(item => item.Push(It.IsAny<Directions>()));

        //    // Act
        //    this.logic.Update();

        //    // Assert
        //    this.MockedGameItem.Verify(item => item.Push(It.IsAny<Directions>()), Times.AtLeastOnce);
        //}

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
        public void BlockShouldNotFall_Test()
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
        public void GameIsOver_Test()
        {
            GameModel.PlayerLife = 1;
            GameModel.GameOver = false;
            GameModel.Map = new GameItem[26, 16];

            GameObject item = new GameObject(Types.Block, 10, 10);
            GameModel.Map[10, 10] = item;

            GameObject nextItem = new GameObject(Types.Player, 10, 11);
            GameModel.Map[10, 11] = nextItem;

            this.logic.Update();

            Assert.That(GameModel.GameOver == true);
        }
    }
}
