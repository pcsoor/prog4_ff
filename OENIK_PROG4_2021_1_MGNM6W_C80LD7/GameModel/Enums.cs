using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class Enums
    {
        public enum UI
        {
            Wall = 1,
            Player = 7,
            BasicBlock = 2,
            Undecided = 0
        }

        /// <summary>
        /// Tile types.
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// Player tile.
            /// </summary>
            Player,

            /// <summary>
            /// Block tile.
            /// </summary>
            Block,

            /// <summary>
            /// Wall tile.
            /// </summary>
            Wall,

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
            Dowm,

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
        }
    }
}
