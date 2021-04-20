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

        private Mock<GameItem> MockedGameItem { get; set; }

        private Mock<IGameModel> MockedGameModel { get; set; }

        /// <summary>
        /// SetUp method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.MockedGameItem = new Mock<GameItem>(MockBehavior.Loose);
            this.MockedGameModel = new Mock<IGameModel>(MockBehavior.Loose);

            this.logic = new GameLogic(this.MockedGameModel.Object);

            // this.types = Types.Block;
        }

        /// <summary>
        /// Test spawn method.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            // Arrange
            this.types = Types.Block;
            this.dir = Directions.Down;

            this.MockedGameItem.Setup(item => item.Push(It.IsAny<Directions>()));

            // Act
            this.logic.Update();

            // Assert
            this.MockedGameItem.Verify(item => item.Push(this.dir), Times.AtLeastOnce);
        }

        /// <summary>
        /// Testing check that last layer is full or not.
        /// </summary>
        [Test]
        public void CheckIfBottomIsFullTest()
        {
            // Arrange
            bool result = true;

            for (int i = 1; i < GameModel.Map.GetLength(0) - 1; i++)
            {
                if (GameModel.Map[i, GameModel.Map.GetLength(1) - 2] == null || GameModel.Map[i, GameModel.Map.GetLength(1) - 2].Type == Enumerators.Types.Player)
                {
                    result = false;
                }
            }

            // Act
            if (result)
            {
                for (int i = 1; i < GameModel.Map.GetLength(0) - 1; i++)
                {
                    GameModel.Map[i, GameModel.Map.GetLength(1) - 2] = null;
                }
            }

            this.logic.CheckIfBottomIsFull();

            // Assert
            Assert.IsTrue(result);
        }
    }
}
