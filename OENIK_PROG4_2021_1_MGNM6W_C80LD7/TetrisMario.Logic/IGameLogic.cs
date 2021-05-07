// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
    public interface IGameLogic
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
        /// <returns>True if the bottom is full.</returns>
        bool CheckIfBottomIsFull();

        /// <summary>
        /// Spawn one block.
        /// </summary>
        void SpawnBlock();
    }
}
