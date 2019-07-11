using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MononokeEngine.Graphics.Drawing.Commands;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Core.Rendering
{
    
    /// <summary>
    /// Renders everything, with no optimization or culling.
    /// </summary>
    internal class BasicRenderer : IRenderer
    {

        private readonly List<GraphicComponent> _graphics;


        internal BasicRenderer()
        {
            _graphics = new List<GraphicComponent>();
        }
        
        
        public IEnumerable<GraphicComponent> GetVisibleGraphics(Camera camera)
        {
            return _graphics;
        }

        public void AddGraphic(GraphicComponent graphic)
        {
            _graphics.Add(graphic);
        }

        public void RemoveGraphic(GraphicComponent graphic)
        {
            _graphics.Remove(graphic);
        }

        public void Update()
        {
            // Do nothing
        }

        
        
        
        
        
        
        
        
        
        
        public bool WillDraw(Camera cam, DrawLine line)
        {
            return true;
        }
        
        

        public bool WillDraw(Camera cam, DrawSprite sprite)
        {
            Sprite spr = sprite.Sprite;
            return WillDrawRect(cam, sprite.Position, spr.Width, spr.Height);
        }

        public bool WillDraw(Camera cam, DrawRect rect)
        {
            Vector2 pos = new Vector2(rect.Rect.X, rect.Rect.Y);
            return WillDrawRect(cam, pos, rect.Rect.Width, rect.Rect.Height);
        }










        private bool WillDrawRect(Camera cam, Vector2 pos, float width, float height)
        {
            float camX = cam.Position.X;
            float camY = cam.Position.Y;

            float x = pos.X;
            float y = pos.Y;
            
            if (x > camX + cam.Width)
                return false;
        
            if (y > camY + cam.Height)
                return false;
        
            if (x + width < camX )
                return false;
        
            if (y + height < camY)
                return false;

            return true;
        }

    }
}