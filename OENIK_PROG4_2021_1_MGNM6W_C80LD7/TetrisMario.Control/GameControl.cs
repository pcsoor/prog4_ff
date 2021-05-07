// <copyright file="GameControl.cs" company="MGNM6W_C80LD7">
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
    using TetrisMario.Model;
    using TetrisMario.Renderer;
    using TetrisMario.Repository;

    /// <summary>
    /// Game control class.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        private IGameModel model;
        private IGameItem gameItem;
        private Logic.GameLogic logic;
        private GameRenderer renderer;
        private Stopwatch stw;
        private DispatcherTimer mainTimer;
        private Repo repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
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
            this.repo = new Repo();
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                this.mainTimer = new DispatcherTimer();
                this.mainTimer.Interval = TimeSpan.FromMilliseconds(1);
                this.mainTimer.Tick += this.TimerTick;
                this.mainTimer.Start();
                if (this.stw.ElapsedMilliseconds > 0 && this.stw.ElapsedMilliseconds % 10000 == 0)
                {
                    this.model.BlockStormActive = -30000;
                }

                if (this.stw.ElapsedMilliseconds > 0 && this.stw.ElapsedMilliseconds % 240000 == 0)
                {
                    this.model.MetalBlocksOnly = -30000;
                }
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
<<<<<<< HEAD
                case Key.Escape: this.logic.Save("Save.txt"); break;
=======
                case Key.Escape: this.repo.Save(); this.repo.SaveHighScores(); break;
>>>>>>> 1b9113473035922357ffbd0d148bb12ffa9cba4a
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
            this.InvalidateVisual();
        }
    }
}