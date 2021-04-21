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
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameModel/Enums.cs
=======
        /// <summary>
        /// Ui elements.
        /// </summary>
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
            /// Undecided element.
            /// </summary>
            Undecided = 0,
        }

        /// <summary>
        /// Tile types.
        /// </summary>
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Model/Enumerators.cs
        public enum Types
        {
            Player,
            Block,
            Wall,
            Undecided,
            Empty
        }

        public enum Directions
        {
            Left,
            Right,
            Up,
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameModel/Enums.cs
            Dowm,
=======

            /// <summary>
            /// Down direction.
            /// </summary>
            Down,

            /// <summary>
            /// Lower left direction.
            /// </summary>
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Model/Enumerators.cs
            LowerLeft,
            LowerRight,
            UpperLeft,
            UpperRight,
            Null
        }

        public enum eWaitTime
        {
            Player = 0,
            PlayerJump = -150,
            PlayerRecover = -50,
            Box = -100
        }
    }
}
