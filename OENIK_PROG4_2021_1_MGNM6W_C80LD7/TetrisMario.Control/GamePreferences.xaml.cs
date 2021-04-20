// <copyright file="GamePreferences.xaml.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Control
{
    using System.Windows;
    using global::GameControl;

    /// <summary>
    /// Interaction logic for GamePreferences.xaml.
    /// </summary>
    public partial class GamePreferences : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GamePreferences"/> class.
        /// </summary>
        public GamePreferences()
        {
            this.InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow game_win = new MainWindow();
            this.Close();
            game_win.Show();
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu main_menu_win = new MainMenu();
            this.Close();
            main_menu_win.Show();
        }
    }
}
