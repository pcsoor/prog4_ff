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

        private Mock<IGameItem> MockedGameItem { get; set; }

        private Mock<IGameModel> MockedGameModel { get; set; }

        private GameLogic GameLogic { get; set; }

        /// <summary>
        /// SetUp method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.MockedGameItem = new Mock<IGameItem>(MockBehavior.Loose);
            this.MockedGameModel = new Mock<IGameModel>(MockBehavior.Loose);
            this.GameLogic = new GameLogic(this.MockedGameModel.Object);

            this.types = Types.Block;
        }

        /// <summary>
        /// Test spawn method.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            this.MockedGameItem.Setup(model => model.Push(It.Is<Directions>(dir => dir.Equals(Directions.Down)))).Returns(this.types);

            this.GameLogic.Update();

            this.MockedGameItem.Verify(p => p.Push(It.Is<Directions>(dir => dir.Equals(Directions.Null))), Times.Never);
        }
    }
}
