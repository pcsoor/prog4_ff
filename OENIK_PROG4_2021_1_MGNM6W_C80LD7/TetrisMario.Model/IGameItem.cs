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
        /// Gets or sets type.
        /// </summary>
        Types Type { get; set; }

        /// <summary>
        /// Gets or sets UiElements.
        /// </summary>
        UiElements UiElement { get; set; }

        /// <summary>
        /// Gets or sets wait time.
        /// </summary>
        int WaitTime { get; set; }

        /// <summary>
        /// Gets or sets x coordinate.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets or sets y coordinate.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Push element to one direction.
        /// </summary>
        /// <param name="direction">direction.</param>
        /// <returns>Types.</returns>
        Types Push(Directions direction);

        /// <summary>
        /// Check items surrounded by one item.
        /// </summary>
        /// <param name="direction">Direction.</param>
        /// <returns>GameItem.</returns>
        GameItem CheckSurrounding(Directions direction);
    }
}
