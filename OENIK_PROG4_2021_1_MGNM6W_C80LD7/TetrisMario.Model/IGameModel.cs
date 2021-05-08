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

        /// <summary>
        /// Gets or sets highscore of the current game.
        /// </summary>
        static int Highscore { get; set; }

        /// <summary>
        /// Gets or sets the time left for the blockstorm event.
        /// </summary>
        static int BlockStormActive { get; set; }

        /// <summary>
        /// Gets or sets the players life.
        /// </summary>
        public static int PlayerLife { get; set; }

        /// <summary>
        /// Gets or sets the time left for metal storm event.
        /// </summary>
        static int MetalBlocksOnly { get; set; }

        /// <summary>
        /// Gets or sets time left for the double jump power up.
        /// </summary>
        static int TimeLeftForDoubleJump { get; set; }

        /// <summary>
        /// Gets or sets the time for double push power up.
        /// </summary>
        static int TimeLeftForDoublePush { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// Gets or sets the players name.
        /// </summary>
        static string PlayerName { get; set; }
    }
}
