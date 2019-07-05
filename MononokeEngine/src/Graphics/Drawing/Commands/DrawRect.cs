using Microsoft.Xna.Framework;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawRect : IDrawCommand
    {
        private readonly Rectangle _rect;
        private readonly Color _color;

        public DrawRect(Rectangle rect, Color color)
        {
            _rect = rect;
            _color = color;
        }
        
        
        public void Execute()
        {
            Sprite px = Mononoke.Graphics.Pixel;
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, _rect, px.ClipRect, _color);
        }
    }
}