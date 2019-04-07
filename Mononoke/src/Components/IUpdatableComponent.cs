using Mononoke.ECS;

namespace Mononoke.Components
{
    
    /// <summary>
    /// Represents a classic component that executes its logic in the
    /// Update method.
    /// </summary>
    public interface IUpdatableComponent : IComponent
    {
        void Update();
    }
}