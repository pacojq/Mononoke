using MononokeEngine;
using MononokeEngine.Graphics;

namespace Sandbox.Components
{
    public class RectDrawer : GraphicComponent
    {
        private float _width;
        private float _height;

        public RectDrawer(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public override void Draw()
        {
            Mononoke.Graphics.Draw.Rect(Entity.X, Entity.Y, _width, _height, true);
        }
    }
}