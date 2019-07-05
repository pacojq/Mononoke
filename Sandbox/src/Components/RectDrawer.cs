using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MononokeEngine;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Input;

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
        
        public override void Render()
        {
            Mononoke.Graphics.Draw.Rect(Entity.X, Entity.Y, _width, _height, true);
        }
    }
}