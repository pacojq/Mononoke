using System.Collections.Generic;
using MononokeEngine.Graphics.Drawing.Commands;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Rendering
{
    internal interface IRenderer
    {
        IEnumerable<GraphicComponent> GetVisibleGraphics(Camera camera);
        
        void AddGraphic(GraphicComponent graphic);
        
        void RemoveGraphic(GraphicComponent graphic);

        void Update();
        
        
        
        
        
        // Will draw...
        // Kind of a visitor stuff

        bool WillDraw(Camera cam, DrawLine line);

        bool WillDraw(Camera cam, DrawSprite sprite);
        
        bool WillDraw(Camera cam, DrawRect rect);
        
        bool WillDraw(Camera cam, SetColor rect);
        
    }
}