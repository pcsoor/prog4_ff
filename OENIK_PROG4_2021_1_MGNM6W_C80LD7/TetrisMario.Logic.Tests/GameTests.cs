// <copyright file="GameTests.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Logic.Tests
{
    using Moq;
    using NUnit.Framework;
    using TetrisMario.Model;

    /// <summary>
    /// Logic tests.
    /// </summary>
    [TestFixture]
    public class GameTests
    {
        private Enumerators.Directions directions;
        private Enumerators.Types types;

        private Mock<IGameItem> MockedGameItem { get; set; }

        /// <summary>
        /// SetUp method.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.MockedGameItem = new Mock<IGameItem>(MockBehavior.Loose);
        }

        /// <summary>
        /// Test spawn method.
        /// </summary>
        public void TestUpdate()
        {
            this.MockedGameItem.Setup(model => model.Push(It.IsAny<Enumerators.Directions>())).Returns(this.types);
        }
    }
}
