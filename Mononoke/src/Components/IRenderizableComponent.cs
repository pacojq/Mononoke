using Mononoke.ECS;

namespace Mononoke.Components
{
    public interface IRenderizableComponent : IComponent
    {
        void Render();
    }
}