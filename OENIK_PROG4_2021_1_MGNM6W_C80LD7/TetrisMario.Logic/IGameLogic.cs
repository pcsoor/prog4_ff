// <copyright file="IGameLogic.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Logic
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
        /// Updates all game item.
        /// </summary>
        void Update();

        /// <summary>
        /// Initialize model.
        /// </summary>
        void InitModel();

        /// <summary>
        /// Checks that bottom layer is wether full or not.
        /// </summary>
        void CheckIfBottomIsFull();

        /// <summary>
        /// Spawn one block.
        /// </summary>
        void SpawnBlock();
    }
}
