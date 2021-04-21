﻿// <copyright file="GameModel.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Model
{
    /// <summary>
    /// Model class.
    /// </summary>
    public class GameModel : IGameModel
    {
        private static GameItem[,] map = new GameItem[26, 16];

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        /// <param name="w">width of the game.</param>
        /// <param name="h">height of the game.</param>
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
        }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        public static GameItem[,] Map
        {
            get { return map; }
            set { map = value; }
        }

        /// <summary>
        /// Gets game width.
        /// </summary>
        public double GameWidth { get; private set; }

        /// <summary>
        /// Gets game height.
        /// </summary>
        public double GameHeight { get; private set; }

        /// <summary>
        /// Gets or sets tile size.
        /// </summary>
        public double TileSize { get; set; }
    }
}
