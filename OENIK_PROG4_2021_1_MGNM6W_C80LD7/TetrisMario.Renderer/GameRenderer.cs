<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameRenderer/MarioTetrisRenderer.cs
﻿using GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
=======
﻿// <copyright file="GameRenderer.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Renderer/GameRenderer.cs

namespace TetrisMario.Renderer
{
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameRenderer/MarioTetrisRenderer.cs
    public class MarioTetrisRenderer
    {
        MarioTetrisModel model;
        Dictionary<string, Brush> myBrushes = new Dictionary<string, Brush>();

        public MarioTetrisRenderer(MarioTetrisModel model)
=======
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using TetrisMario.Model;

    /// <summary>
    /// Game renderer class.
    /// </summary>
    public class GameRenderer
    {
        private IGameModel model;
        private Dictionary<string, Brush> myBrushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="GameRenderer"/> class.
        /// </summary>
        /// <param name="model">model reference.</param>
        public GameRenderer(IGameModel model)
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Renderer/GameRenderer.cs
        {
            this.model = model;
        }

        Brush GetBrush(string fname, bool isTiled)
        {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameRenderer/MarioTetrisRenderer.cs
            if (!myBrushes.ContainsKey(fname))
=======
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Karakter.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Blue Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets wall's brush.
        /// </summary>
        public Brush WallBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Border.bmp", true);
            }
        }

        /// <summary>
        /// Returns a brush for a specific item.
        /// </summary>
        /// <param name="fname">file name.</param>
        /// <param name="isTiled">check if tiled.</param>
        /// <returns>brush.</returns>
        public Brush GetBrush(string fname, bool isTiled)
        {
            if (!this.myBrushes.ContainsKey(fname))
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Renderer/GameRenderer.cs
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                bmp.EndInit();
                ImageBrush ib = new ImageBrush(bmp);
                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    ib.Viewport = new Rect(0, 0, model.TileSize, model.TileSize);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                myBrushes[fname] = ib;
            }

            return myBrushes[fname];
        }

        Brush PlayerBrush { get { return GetBrush("GameRenderer.Images.Karakter.bmp", false); } }

        Brush BlockBrush { get { return GetBrush("GameRenderer.Images.Blue Brick.bmp", false); } }

        Brush WallBrush { get { return GetBrush("GameRenderer.Images.Border.bmp", true); } }

        public void BuildDisplay(DrawingContext ctx)
        {
            for (int x = 0; x < MarioTetrisModel.Map.GetLength(0); x++)
            {
<<<<<<< HEAD:OENIK_PROG4_2021_1_MGNM6W_C80LD7/GameRenderer/MarioTetrisRenderer.cs
                for (int y = 0; y < MarioTetrisModel.Map.GetLength(1); y++)
                {
                    if (MarioTetrisModel.Map[x, y] != null)
                    {
                        if (MarioTetrisModel.Map[x, y].Type == Enums.Types.Block)
                        {
                            Geometry box = new RectangleGeometry(new Rect(x * model.TileSize, y * model.TileSize, model.TileSize, model.TileSize));
                            ctx.DrawGeometry(BlockBrush, null, box);
                        }
                        if (MarioTetrisModel.Map[x, y].Type == Enums.Types.Wall)
                        {
                            Geometry box = new RectangleGeometry(new Rect(x * model.TileSize, y * model.TileSize, model.TileSize, model.TileSize));
                            ctx.DrawGeometry(WallBrush, null, box);
                        }
                        if (MarioTetrisModel.Map[x, y].Type == Enums.Types.Player)
                        {
                            Geometry box = new RectangleGeometry(new Rect(x * model.TileSize, y * model.TileSize, model.TileSize, model.TileSize));
                            ctx.DrawGeometry(PlayerBrush, null, box);
=======
                for (int x = 0; x < GameModel.Map.GetLength(0); x++)
                {
                    for (int y = 0; y < GameModel.Map.GetLength(1); y++)
                    {
                        if (GameModel.Map[x, y] != null)
                        {
                            if (GameModel.Map[x, y].Type == Enumerators.Types.Block)
                            {
                                Geometry box = new RectangleGeometry(new Rect(x * this.model.TileSize, y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                ctx.DrawGeometry(this.BlockBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Wall)
                            {
                                Geometry box = new RectangleGeometry(new Rect(x * this.model.TileSize, y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                ctx.DrawGeometry(this.WallBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Player)
                            {
                                Geometry box = new RectangleGeometry(new Rect(x * this.model.TileSize, y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                ctx.DrawGeometry(this.PlayerBrush, null, box);
                            }
>>>>>>> ab0325c16c9dd1e1899ba7370d1a4fca6bb9712d:OENIK_PROG4_2021_1_MGNM6W_C80LD7/TetrisMario.Renderer/GameRenderer.cs
                        }
                    }
                }
            }
        }
    }
}
