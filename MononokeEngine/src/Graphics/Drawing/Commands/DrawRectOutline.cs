using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Utils;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawRectOutline : IDrawCommand
    {
        private readonly Rectangle _rect;
        private readonly Color _color;
        private readonly int _border;
        
        
        private readonly Rectangle _top;
        private readonly Rectangle _bot;
        private readonly Rectangle _right;
        private readonly Rectangle _left;
        

        public DrawRectOutline(Rectangle rect, Color color, int border = 1)
        {
            _rect = rect;
            _color = color;
            
            _top = new Rectangle(rect.X, rect.Y, rect.Width, border);
            _bot = new Rectangle(rect.X, rect.Y + rect.Height - border, rect.Width, border);
            _right = new Rectangle(rect.X + rect.Width - border, rect.Y, border, rect.Height);
            _left = new Rectangle(rect.X, rect.Y, border, rect.Height);
        }
        
        
        public void Execute()
        {
            Texture px = Mononoke.Graphics.Pixel;
            
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture2D, _top, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture2D, _bot, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture2D, _right, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture2D, _left, px.ClipRect, _color);
        }
    }
}