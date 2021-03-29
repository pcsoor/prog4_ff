// <copyright file="IGameModel.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
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
    internal interface IGameModel
    {
        /// <summary>
        /// Gets or sets place of walls.
        /// </summary>
        int[,] Walls { get; set; }

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
