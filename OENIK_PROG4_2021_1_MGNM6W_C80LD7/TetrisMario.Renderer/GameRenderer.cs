// <copyright file="GameRenderer.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Renderer
{
    using System;
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
        {
            this.model = model;
        }

        /// <summary>
        /// Gets player's brush.
        /// </summary>
        public Brush PlayerBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Karakter.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BlueBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Blue Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BrownBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Brown Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreenBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Green Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreyBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Grey Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GoldBlockBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Gold Brick.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BlueMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Blue Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreenMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Green Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush BrownMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Brown Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GoldMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Gold Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush GreyMetalBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Grey Metal.bmp", false);
            }
        }

        /// <summary>
        /// Gets block's brush.
        /// </summary>
        public Brush PowerUpBrush
        {
            get
            {
                return this.GetBrush("TetrisMario.Renderer.Images.Power Up.bmp", false);
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
            {
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                bmp.EndInit();
                ImageBrush ib = new ImageBrush(bmp);
                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    ib.Viewport = new Rect(0, 0, this.model.TileSize, this.model.TileSize);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                this.myBrushes[fname] = ib;
            }

            return this.myBrushes[fname];
        }

        /// <summary>
        /// Builder method.
        /// </summary>
        /// <param name="ctx">drawing context.</param>
        public void BuildDisplay(DrawingContext ctx)
        {
            if (ctx != null)
            {
                for (int x = 0; x < GameModel.Map.GetLength(0); x++)
                {
                    for (int y = 0; y < GameModel.Map.GetLength(1); y++)
                    {
                        if (GameModel.Map[x, y] != null)
                        {
                            Geometry box = new RectangleGeometry(new Rect(x * this.model.TileSize, y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                            if (GameModel.Map[x, y].Type == Enumerators.Types.Block)
                            {
                                if (GameModel.Map[x, y].Color == 1)
                                {
                                    ctx.DrawGeometry(this.BlueBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 2)
                                {
                                    ctx.DrawGeometry(this.GreenBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 3)
                                {
                                    ctx.DrawGeometry(this.GoldBlockBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 4)
                                {
                                    ctx.DrawGeometry(this.GreyBlockBrush, null, box);
                                }
                                else if(GameModel.Map[x, y].Color == 5)
                                {
                                    ctx.DrawGeometry(this.BrownBlockBrush, null, box);
                                }
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Metal)
                            {
                                if (GameModel.Map[x, y].Color == 1)
                                {
                                    ctx.DrawGeometry(this.BlueMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 2)
                                {
                                    ctx.DrawGeometry(this.GreenMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 3)
                                {
                                    ctx.DrawGeometry(this.GoldMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 4)
                                {
                                    ctx.DrawGeometry(this.GreyMetalBrush, null, box);
                                }
                                else if (GameModel.Map[x, y].Color == 5)
                                {
                                    ctx.DrawGeometry(this.BrownMetalBrush, null, box);
                                }
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.PowerUp)
                            {
                                ctx.DrawGeometry(this.PowerUpBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Wall)
                            {
                                ctx.DrawGeometry(this.WallBrush, null, box);
                            }

                            if (GameModel.Map[x, y].Type == Enumerators.Types.Player)
                            {
                                ctx.DrawGeometry(this.PlayerBrush, null, box);
                            }
                        }
                    }
                }
            }
        }
    }
}
