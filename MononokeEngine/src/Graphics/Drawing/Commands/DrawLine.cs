using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Scenes;
using MononokeEngine.Utils;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class DrawLine : AbstractDrawCommand
    {
        private readonly Vector2 _p0;
        private readonly Vector2 _p1;
        private readonly Color _color;

        public DrawLine(Vector2 p0, Vector2 p1, Color color)
        {
            _p0 = p0;
            _p1 = p1;
            _color = color;
        }
        
        
        public override void Execute()
        {
            var angle = Math.PointDirection(_p0, _p1);
            var dist = Math.PointDistance(_p0, _p1);
            Sprite px = Mononoke.Graphics.Pixel;
            
            Mononoke.Graphics.SpriteBatch.Draw(
                    px.Texture, 
                    _p0, 
                    px.ClipRect, 
                    _color,
                    angle, 
                    Vector2.Zero,
                    new Vector2(dist, 1), 
                    SpriteEffects.None, 
                    0
                );
        }
        
        
        public override bool Accept(Camera cam, IRenderer renderer)
        {
            return renderer.WillDraw(cam, this);
        }
    }
}