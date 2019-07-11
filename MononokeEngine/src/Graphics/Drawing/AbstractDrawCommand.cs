using MononokeEngine.Graphics.Core.Rendering;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing
{
    internal abstract class AbstractDrawCommand : IDrawCommand
    {
        public GraphicComponent Graphic { get; set; }

        public abstract void Execute();

        public abstract bool Accept(Camera cam, IRenderer renderer);
    }
}