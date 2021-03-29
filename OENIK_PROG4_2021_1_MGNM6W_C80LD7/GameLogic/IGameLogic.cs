// <copyright file="IGameLogic.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// IGameLogic interface.
    /// </summary>
    internal interface IGameLogic
    {
        /// <summary>
        /// Moves character left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Moves character left.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Shoot with character.
        /// </summary>
        void Shoot();

        /// <summary>
        /// jump with character.
        /// </summary>
        void Jump();

        /// <summary>
        /// Damage taken by character.
        /// </summary>
        void Damage();
    }
}
