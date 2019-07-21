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

        private readonly float _angle;
        private readonly float _dist;
        

        public DrawLine(Vector2 p0, Vector2 p1, Color color)
        {
            _p0 = p0;
            _p1 = p1;
            _color = color;
            
            _angle = Math.PointDirection(_p0, _p1);
            _dist = Math.PointDistance(_p0, _p1);
        }
        
        
        public override void Execute(Camera cam)
        {
            Vector2 relP0 = cam.GetRenderPosition(_p0);
            Sprite px = Mononoke.Graphics.Pixel;
            
            // Draw a scaled pixel
            
            Mononoke.Graphics.SpriteBatch.Draw(
                    px.Texture, 
                    relP0, 
                    px.ClipRect, 
                    _color,
                    _angle, 
                    Vector2.Zero,
                    new Vector2(_dist, 1), 
                    SpriteEffects.None, 
                    0
                );
        }
        
        
        public override bool Accept(Camera cam, IGraphicsCulling graphicsCulling)
        {
            return graphicsCulling.WillDraw(cam, this);
        }
    }
}