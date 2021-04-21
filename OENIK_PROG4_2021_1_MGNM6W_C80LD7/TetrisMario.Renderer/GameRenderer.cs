// <copyright file="GameRenderer.cs" company="MGNM6W_C80LD7">
// Copyright (c) MGNM6W_C80LD7. All rights reserved.
// </copyright>

namespace TetrisMario.Renderer
{
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
                        }
                    }
                }
            }
        }
    }
}
