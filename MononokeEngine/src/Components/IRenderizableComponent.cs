using MononokeEngine.ECS;

namespace MononokeEngine.Components
{
    public interface IRenderizableComponent : IComponent
    {
        void Render();
    }
}