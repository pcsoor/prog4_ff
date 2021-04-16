// <copyright file="IGameModel.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace GameModel
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Game Model Interface.
    /// </summary>
    interface IGameModel
    {
        /// <summary>
        /// Gets or sets place of walls.
        /// </summary>
        int[,] Map { get; set; }

        /// <summary>
        /// Gets or sets blocks.
        /// </summary>
        string Block { get; set; }

        /// <summary>
        /// Gets or sets Mario's position.
        /// </summary>
        Point Mario { get; set; }
    }
}
