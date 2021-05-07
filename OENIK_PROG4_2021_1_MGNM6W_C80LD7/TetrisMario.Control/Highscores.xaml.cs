// <copyright file="Highscores.xaml.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Control
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for Highscores.xaml.
    /// </summary>
    public partial class Highscores : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Highscores"/> class.
        /// </summary>
        public Highscores()
        {
            this.InitializeComponent();
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            menu.Show();
            this.Close();
        }
    }
}
