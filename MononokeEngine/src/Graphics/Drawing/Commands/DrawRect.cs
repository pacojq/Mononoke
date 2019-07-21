using Microsoft.Xna.Framework;
using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawRect : AbstractDrawCommand
    {
        public Rectangle Rect { get; }
        private readonly Color _color;

        public DrawRect(Rectangle rect, Color color)
        {
            Rect = rect;
            _color = color;
        }
        
        
        public override void Execute(Camera cam)
        {
            Rectangle rect = new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height);
            Vector2 rel = cam.GetRenderPosition(new Vector2(rect.X, rect.Y));
            rect.X = (int) rel.X;
            rect.Y = (int) rel.Y;
            
            Sprite px = Mononoke.Graphics.Pixel;
            Mononoke.Graphics.SpriteBatch.Draw(px.Texture, rect, px.ClipRect, _color);
        }
        
        public override bool Accept(Camera cam, IGraphicsCulling graphicsCulling)
        {
            return graphicsCulling.WillDraw(cam, this);
        }
    }
}