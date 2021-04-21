using GameModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameRenderer
{
    public class MarioTetrisRenderer
    {
        MarioTetrisModel model;
        Dictionary<string, Brush> myBrushes = new Dictionary<string, Brush>();

        public MarioTetrisRenderer(MarioTetrisModel model)
        {
            this.model = model;
        }

        Brush GetBrush(string fname, bool isTiled)
        {
            if (!myBrushes.ContainsKey(fname))
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
                        }
                    }
                }
            }
        }
    }
}
