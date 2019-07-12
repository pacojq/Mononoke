using Microsoft.Xna.Framework;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawRectOutline : DrawRect
    {
        private readonly Color _color;
        private readonly int _border;
        
        
        

        public DrawRectOutline(Rectangle rect, Color color, int border = 1) : base(rect, color)
        {
            _color = color;
            _border = border;
        }
        
        
        public override void Execute(Camera cam)
        {
            Sprite px = Mononoke.Graphics.Pixel;
            
            Rectangle rect = new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
            Vector2 rel = cam.GetRenderPosition(new Vector2(rect.X, rect.Y));
            rect.X = (int) rel.X;
            rect.Y = (int) rel.Y;
            
            var top = new Rectangle(rect.X, rect.Y, rect.Width, _border);
            var bot = new Rectangle(rect.X, rect.Y + rect.Height - _border, rect.Width, _border);
            var right = new Rectangle(rect.X + rect.Width - _border, rect.Y, _border, rect.Height);
            var left = new Rectangle(rect.X, rect.Y, _border, rect.Height);
            
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, top, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, bot, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, right, px.ClipRect, _color);
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, left, px.ClipRect, _color);
        }
    }
}