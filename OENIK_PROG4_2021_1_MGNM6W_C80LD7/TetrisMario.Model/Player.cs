// <copyright file="Player.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static TetrisMario.Model.Enumerators;

    /// <summary>
    /// Player game item class.
    /// </summary>
    public class Player : GameItem
    {
        private static Player instance;

        private bool canShoot = true;

        private Directions lastMove = Directions.Null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="x">x coordinates.</param>
        /// <param name="y">y coordinates.</param>
        public Player(int x, int y)
        {
            this.Type = Types.Player;
            this.UiElement = UiElements.Player;
            instance = this;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the player can shoot.
        /// </summary>
        public bool CanShoot
        {
            get { return this.canShoot; } set { this.canShoot = value; }
        }

        /// <summary>
        /// Gets or sets last move.
        /// </summary>
        public Directions LastMove
        {
            get { return this.lastMove; } set { this.lastMove = value; }
        }
    }
}
