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
            GameModel.Map = new GameItem[26,16];

            GameModel.Map[0, GameModel.Map.GetLength(1) - 2] = null;
            bool firstResult = this.logic.CheckIfBottomIsFull();

            GameModel.Map[1, GameModel.Map.GetLength(1) - 2] = new GameItem();
            GameModel.Map[1, GameModel.Map.GetLength(1) - 2].Type = Types.Player;
            bool secondResult = this.logic.CheckIfBottomIsFull();

            Assert.False(firstResult);
            Assert.False(secondResult);
        }

        [Test]
        public void ShootTest()
        {
            Player testPlayer = new Player(10, 10);
            GameModel.Map[testPlayer.X, testPlayer.Y - 1] = null;

            bool result = this.logic.Shoot(testPlayer);

            Assert.IsTrue(result);
        }
    }
}
