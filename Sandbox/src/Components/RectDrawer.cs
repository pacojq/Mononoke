using MononokeEngine;
using MononokeEngine.Graphics;

namespace Sandbox.Components
{
    public class RectDrawer : Graphic
    {
        private float _width;
        private float _height;

        public RectDrawer(float width, float height)
        {
            _width = width;
            _height = height;
        }
        
        protected override void RenderImpl()
        {
            Mononoke.Graphics.Draw.Rect(Entity.X, Entity.Y, _width, _height, true);
        }
    }
}