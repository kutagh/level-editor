using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
    class Tile
    {
        public bool passable { get; private set; }
        public Texture2D texture { get; private set; }
        
        public void Draw(SpriteBatch sb, int x, int y, int widthModifier = 0, int heightModifier = 0)
        {
            sb.Draw(texture, new Vector2(x * texture.Width + widthModifier, y * texture.Height + heightModifier), Color.White);
        }
    }
}
