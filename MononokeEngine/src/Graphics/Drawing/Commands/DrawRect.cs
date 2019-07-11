using Microsoft.Xna.Framework;
using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawRect : AbstractDrawCommand
    {
        private readonly Rectangle _rect;
        private readonly Color _color;

        public DrawRect(Rectangle rect, Color color)
        {
            _rect = rect;
            _color = color;
        }
        
        
        public override void Execute()
        {
            Sprite px = Mononoke.Graphics.Pixel;
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, _rect, px.ClipRect, _color);
        }
        
        public override bool Accept(Camera cam, IRenderer renderer)
        {
            return renderer.WillDraw(cam, this);
        }
    }
}