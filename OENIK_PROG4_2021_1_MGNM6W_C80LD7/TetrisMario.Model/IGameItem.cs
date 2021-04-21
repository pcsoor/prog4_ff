// <copyright file="IGameItem.cs" company="MGNM6W_C80LD7">
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
    /// Game item interface.
    /// </summary>
    public interface IGameItem
    {
        /// <summary>
        /// Push element to one direction.
        /// </summary>
        /// <param name="direction">direction.</param>
        /// <returns>Types.</returns>
        Types Push(Directions direction);

        /// <summary>
        /// Move item.
        /// </summary>
        /// <param name="newX">new x coordinate.</param>
        /// <param name="newY">new y coordinate.</param>
        /// <returns>Types.</returns>
        Types Move(int newX, int newY);

        /// <summary>
        /// Check items surrounded by one item.
        /// </summary>
        /// <param name="direction">Direction.</param>
        /// <returns>GameItem.</returns>
        GameItem CheckSurrounding(Directions direction);
    }
}
