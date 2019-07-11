using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing
{
    internal interface IDrawCommand
    {
        GraphicComponent Graphic { get; set; }
        
        void Execute();

        bool Accept(Camera cam, IRenderer renderer);
    }
}