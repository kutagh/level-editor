using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    class Level
    {
        Tile[,] level;
        Heightmap heightmap;

        public int height { get { return level.GetUpperBound(1) + 1; } }
        public int width { get { return level.GetUpperBound(0) + 1; } }

        public Level(int width = 1, int height = 1)
        {
            level = new Tile[width, height];
        }

        public void Grow(int toLeft = 0, int toRight = 0, int toAbove = 0, int toBelow = 0)
        {
            int newWidth = width + toLeft + toRight;
            int newHeight = height + toAbove + toBelow;
            Tile[,] newLevel = new Tile[newWidth, newHeight];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newLevel[x + toLeft, y + toAbove] = level[x,y];
                }
            }
            level = newLevel;
            heightmap.Grow(toLeft, toRight, toAbove, toBelow);
        }

        public void Shrink(int fromLeft = 0, int fromRight = 0, int fromAbove = 0, int fromBelow = 0)
        {
            int newWidth = width - fromLeft - fromRight;
            int newHeight = height - fromAbove - fromBelow;
            Tile[,] newLevel = new Tile[newWidth, newHeight];
            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    newLevel[x, y] = level[fromLeft + x, fromAbove + y];

                }
            }
            level = newLevel;
            heightmap.Shrink(fromLeft, fromRight, fromAbove, fromBelow);
        }

        public void Draw(SpriteBatch sb, int widthModifier = 0, int heightModifier = 0)
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    level[x, y].Draw(sb, x, y, widthModifier, heightModifier);
        }

        public Tile this[int x, int y]
        {
            get {
                if (x < 0 || x >= width || y < 0 || y >= height)
                    return null;
                return level[x, y]; }
            set {
                if (x < 0 || x >= width || y < 0 || y >= height)
                    return;
                level[x, y] = value; }
        }
    }
}
