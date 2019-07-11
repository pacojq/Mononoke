using Microsoft.Xna.Framework;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawRectOutline : DrawRect
    {
        private readonly Color _color;
        private readonly int _border;
        
        
        private readonly Rectangle _top;
        private readonly Rectangle _bot;
        private readonly Rectangle _right;
        private readonly Rectangle _left;
        

        public DrawRectOutline(Rectangle rect, Color color, int border = 1) : base(rect, color)
        {
            _color = color;
            
            _top = new Rectangle(rect.X, rect.Y, rect.Width, border);
            _bot = new Rectangle(rect.X, rect.Y + rect.Height - border, rect.Width, border);
            _right = new Rectangle(rect.X + rect.Width - border, rect.Y, border, rect.Height);
            _left = new Rectangle(rect.X, rect.Y, border, rect.Height);
        }
        
        
        public override void Execute()
        {
            Sprite px = Mononoke.Graphics.Pixel;
            
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, _top, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, _bot, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, _right, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, _left, px.ClipRect, _color);
        }
    }
}