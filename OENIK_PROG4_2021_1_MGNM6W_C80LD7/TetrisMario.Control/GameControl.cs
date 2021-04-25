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
            stw.Start();
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.KeyDown += this.Win_KeyDown;
                this.mainTimer = new DispatcherTimer();
                this.mainTimer.Interval = TimeSpan.FromMilliseconds(1);
                this.mainTimer.Tick += this.TimerTick;
                this.mainTimer.Start();
                if (stw.ElapsedMilliseconds % 360000 == 0)
                {
                    model.BlockStormActive = true;
                }

                if (stw.ElapsedMilliseconds % 180000 == 0)
                {
                    model.MetalBlocksOnly = true;
                }

                if (stw.ElapsedTicks % 420000 == 0)
                {
                    model.BlockStormActive = false;
                }

                if (stw.ElapsedMilliseconds % 240000 == 0)
                {
                    model.MetalBlocksOnly = false;
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
                case Key.Escape: this.logic.Save(); break;
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