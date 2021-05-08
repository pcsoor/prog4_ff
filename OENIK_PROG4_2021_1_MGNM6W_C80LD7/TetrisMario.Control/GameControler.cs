// <copyright file="GameControler.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Control
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using GameControl;
    using TetrisMario.Model;
    using TetrisMario.Renderer;
    using TetrisMario.Repository;

    /// <summary>
    /// Game control class.
    /// </summary>
    public class GameControler : FrameworkElement
    {
        /// <summary>
        /// Name of the player.
        /// </summary>
        public new string Name = string.Empty;
        private int elapsedTime = 0;
        private IGameModel model;
        private IGameItem gameItem;
        private Logic.GameLogic logic;
        private GameRenderer renderer;
        private Stopwatch stw;
        private DispatcherTimer mainTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControler"/> class.
        /// </summary>
        public GameControler()
        {
            this.Loaded += this.MarioTetrisControl_Loaded;
        }

        /// <summary>
        /// Calls renderer.
        /// </summary>
        /// <param name="drawingContext">drawing context.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                this.renderer.BuildDisplay(drawingContext);
            }
        }

        private void MarioTetrisControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.stw = new Stopwatch();
            this.model = new GameModel(this.ActualWidth, this.ActualHeight);
            this.gameItem = new GameItem();
            this.logic = new Logic.GameLogic(this.model);
            this.renderer = new GameRenderer(this.model);
            this.stw.Start();
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                this.mainTimer = new DispatcherTimer();
                this.mainTimer.Interval = TimeSpan.FromMilliseconds(1);
                this.mainTimer.Tick += this.TimerTick;
                this.mainTimer.Start();
            }

            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W: this.logic.Inputs.Enqueue(Enumerators.Directions.Up); break;
                case Key.S: this.logic.Inputs.Enqueue(Enumerators.Directions.Shoot); break;
                case Key.A: this.logic.Inputs.Enqueue(Enumerators.Directions.Left); break;
                case Key.D: this.logic.Inputs.Enqueue(Enumerators.Directions.Right); break;
                case Key.Escape: Repo.Save(); Repo.SaveHighScores(); break;
            }

            this.InvalidateVisual();
        }

        /// <summary>
        /// one tick in game.
        /// </summary>
        /// <param name="sender">sender.</param>
        /// <param name="e">event.</param>
        private void TimerTick(object sender, EventArgs e)
        {
            this.logic.SpawnBlock();
            this.logic.Update();
            this.logic.CheckIfBottomIsFull();
            this.elapsedTime += 8;
            GameModel.BlockStormActive += 8;
            GameModel.MetalBlocksOnly += 8;
            GameModel.TimeLeftForDoubleJump += 8;
            GameModel.TimeLeftForDoublePush += 8;
            if (this.model.GameOver)
            {
                this.GameOver();
            }

            if (this.elapsedTime % 15000 == 0)
            {
                GameModel.BlockStormActive = -10000;
            }

            if (this.elapsedTime % 35000 == 0)
            {
                GameModel.MetalBlocksOnly = -5000;
            }

            this.InvalidateVisual();
        }

        private void GameOver()
        {
            this.stw.Stop();
            this.stw.Reset();
            Repo.SaveHighScores();
            MessageBox.Show("Game Over!");
            this.model.GameOver = false;
            this.mainTimer.Stop();
            Repo.Load("Save2.txt");
            MainMenu menu = new MainMenu();
            menu.Show();
            Window win = Window.GetWindow(this);
            win.Close();
        }
    }
}