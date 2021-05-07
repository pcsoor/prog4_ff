// <copyright file="Highscore.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Control
{
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Class for storing highscores.
    /// </summary>
    public class Highscore : ObservableObject
    {
        /// <summary>
        /// Gets or sets name of the player and their score.
        /// </summary>
        public string Data { get; set; }
    }
}
