using MononokeEngine.Graphics.Rendering;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Drawing
{
    internal interface IDrawCommand
    {
        void Execute();

        bool Accept(Camera cam, IRenderer renderer);
    }
}