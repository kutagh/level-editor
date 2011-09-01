using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor
{
    class Heightmap
    {
        int[,] level;

        public int height { get { return level.GetUpperBound(1) + 1; } }
        public int width { get { return level.GetUpperBound(0) + 1; } }

        public Heightmap(int width = 1, int height = 1)
        {
            level = new int[width, height];
        }

        public void Grow(int toLeft = 0, int toRight = 0, int toAbove = 0, int toBelow = 0)
        {
            int newWidth = width + toLeft + toRight;
            int newHeight = height + toAbove + toBelow;
            int[,] newLevel = new int[newWidth, newHeight];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    newLevel[x + toLeft, y + toAbove] = level[x,y];
                }
            }
            level = newLevel;
        }

        public void Shrink(int fromLeft = 0, int fromRight = 0, int fromAbove = 0, int fromBelow = 0)
        {
            int newWidth = width - fromLeft - fromRight;
            int newHeight = height - fromAbove - fromBelow;
            int[,] newLevel = new int[newWidth, newHeight];
            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    newLevel[x, y] = level[fromLeft + x, fromAbove + y];

                }
            }
            level = newLevel;
        }

        public int this[int x, int y]
        {
            get {
                if (x < 0 || x >= width || y < 0 || y >= height)
                    return int.MinValue;
                return level[x, y]; }
            set {
                if (x < 0 || x >= width || y < 0 || y >= height)
                    return;
                level[x, y] = value; }
        }
    }
}
