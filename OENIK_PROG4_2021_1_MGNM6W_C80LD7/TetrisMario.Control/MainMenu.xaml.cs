// <copyright file="MainMenu.xaml.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Control
{
    using System.Windows;
    using global::GameControl;
    using TetrisMario.Repository;

    /// <summary>
    /// Interaction logic for MainMenu.xaml.
    /// </summary>
    public partial class MainMenu : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenu"/> class.
        /// </summary>
        public MainMenu()
        {
            this.InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow game_win = new MainWindow();
            this.Close();
            game_win.Show();
        }

        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            Highscores scores_win = new Highscores();
            this.Close();
            scores_win.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            MainWindow game_win = new MainWindow();
            Repo.Load("Save.txt");
            this.Close();
            game_win.Show();
        }
    }
}
