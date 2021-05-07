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
        public MainViewModel()
        {
            this.HighScores = new ObservableCollection<string>();

            if (this.IsInDesignMode)
            {
                this.HighScores.Add("Erik");
                this.HighScores.Add("Peti");
            }
            else
            {
                this.HighScores.Add("asd");
            }
        }

        /// <summary>
        /// gets or sets highsocers.
        /// </summary>
        public ObservableCollection<string> HighScores { get; private set; }
    }
}
