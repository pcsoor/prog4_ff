// <copyright file="MainViewModel.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Control
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Main view model for the highscore window.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            this.HighScores = new ObservableCollection<Highscore>();

            if (this.IsInDesignMode)
            {
                Highscore h1 = new Highscore() { Data = "erik - 10000" };
                this.HighScores.Add(h1);
            }
            else
            {
                string[] lines = Repository.Repo.LoadHighscores();
                for (int i = 0; i < lines.Length; i++)
                {
                    Highscore newHighscore = new Highscore() { Data = lines[i] };
                    this.HighScores.Add(newHighscore);
                }
            }
        }

        /// <summary>
        /// Gets ts highscoers.
        /// </summary>
        public ObservableCollection<Highscore> HighScores { get; private set; }

        /// <summary>
        /// Gets or sets the selected highscore.
        /// </summary>
        public string HighscoreSelected { get; set; }
    }
}
