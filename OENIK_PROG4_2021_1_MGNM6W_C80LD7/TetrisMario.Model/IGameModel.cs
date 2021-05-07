// <copyright file="IGameModel.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Model
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
    public interface IGameModel
    {
        /// <summary>
        /// Gets game width.
        /// </summary>
        double GameWidth { get; }

        /// <summary>
        /// Gets game height.
        /// </summary>
        double GameHeight { get; }

        /// <summary>
        /// Gets or sets tile size.
        /// </summary>
        double TileSize { get; set; }

        static int Highscore { get; set; }

        int BlockStormActive { get; set; }

        public int playerLife { get; set; }

        int MetalBlocksOnly { get; set; }

        int timeLeftForDoubleJump { get; set; }

        int timeLeftForDoublePush { get; set; }
        bool GameOver { get; set; }
    }
}
