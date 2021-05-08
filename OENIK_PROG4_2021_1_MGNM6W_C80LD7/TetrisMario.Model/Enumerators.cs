// <copyright file="Enumerators.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Enums class.
    /// </summary>
    public static class Enumerators
    {
        /// <summary>
        /// Ui elements.
        /// </summary>
        [Flags]
        public enum UiElements
        {
            /// <summary>
            /// Wall element.
            /// </summary>
            Wall = 1,

            /// <summary>
            /// Player element.
            /// </summary>
            Player = 7,

            /// <summary>
            /// Basic block element.
            /// </summary>
            BasicBlock = 2,

            /// <summary>
            /// Metal block element.
            /// </summary>
            Metal = 3,

            /// <summary>
            /// Power UP block element.
            /// </summary>
            PowerUp = 4,

            /// <summary>
            /// Undecided element.
            /// </summary>
            None = 0,
        }

        /// <summary>
        /// Tile types.
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// Power Up block type.
            /// </summary>
            PowerUp,

            /// <summary>
            /// Metal block type.
            /// </summary>
            Metal,

            /// <summary>
            /// Player block type.
            /// </summary>
            Player,

            /// <summary>
            /// Basic block type.
            /// </summary>
            Block,

            /// <summary>
            /// Wall block type.
            /// </summary>
            Wall,

            /// <summary>
            /// Bullet block type.
            /// </summary>
            Bullet,

            /// <summary>
            /// Undecided tile.
            /// </summary>
            Undecided,

            /// <summary>
            /// Empty tile.
            /// </summary>
            Empty,
        }

        /// <summary>
        /// All direction.
        /// </summary>
        public enum Directions
        {
            /// <summary>
            /// Left direction.
            /// </summary>
            Left,

            /// <summary>
            /// Right direction.
            /// </summary>
            Right,

            /// <summary>
            /// Up direction.
            /// </summary>
            Up,

            /// <summary>
            /// Down direction.
            /// </summary>
            Down,

            /// <summary>
            /// Lower left direction.
            /// </summary>
            LowerLeft,

            /// <summary>
            /// Lower right direction.
            /// </summary>
            LowerRight,

            /// <summary>
            /// Upper left direction.
            /// </summary>
            UpperLeft,

            /// <summary>
            /// Upper right direction.
            /// </summary>
            UpperRight,

            /// <summary>
            /// Not defined direction.
            /// </summary>
            Null,

            /// <summary>
            /// Shoot action type.
            /// </summary>
            Shoot,
        }

        /// <summary>
        /// Wait times of specific game items.
        /// </summary>
        public enum WaitTime
        {
            /// <summary>
            /// Player's wait time.
            /// </summary>
            Player = 0,

            /// <summary>
            /// Player's jump wait time.
            /// </summary>
            PlayerJump = -150,

            /// <summary>
            /// Player's recover time.
            /// </summary>
            PlayerRecover = -50,

            /// <summary>
            /// Box's wait time.
            /// </summary>
            Box = -100,

            /// <summary>
            /// Double jump time.
            /// </summary>
            DoubleJump = -60000,

            /// <summary>
            /// Double push time.
            /// </summary>
            DoublePush = -60000,

            /// <summary>
            /// Wait time till the next block spawning.
            /// </summary>
            NextBlockBasic = -500,

            /// <summary>
            /// Wait time till the next block spawning when block storm is active.
            /// </summary>
            NextBlockBlockStorm = -250,

            /// <summary>
            /// Wait time for bullets next movement.
            /// </summary>
            BulletWaitTime = -10,
        }

        /// <summary>
        /// Points you get for certain events.
        /// </summary>
        public enum ScorePoints
        {
            /// <summary>
            /// The score given for filling the bottom of the map.
            /// </summary>
            BottomFull = 1000,
        }
    }
}
