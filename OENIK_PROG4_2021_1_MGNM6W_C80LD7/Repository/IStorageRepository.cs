// <copyright file="IStorageRepository.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Storage repository interface.
    /// </summary>
    internal interface IStorageRepository
    {
        /// <summary>
        /// Gets or sets highscore.
        /// </summary>
        int Highscore { get; set; }

        /// <summary>
        /// Gets or sets game board.
        /// </summary>
        int[,] Board { get; set; }
    }
}
