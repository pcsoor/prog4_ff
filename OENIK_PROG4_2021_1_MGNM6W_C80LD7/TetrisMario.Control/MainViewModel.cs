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

    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// gets or sets highsocers.
        /// </summary>
        public ObservableCollection<Highscore> HighScores { get; private set; }

        string highscoreSelected;

        public string HighscoreSelected { get; set; }

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
                    HighScores.Add(newHighscore);
                }
            }
        }
    }
}
