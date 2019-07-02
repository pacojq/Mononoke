using MonoGarden.ECS;

namespace MonoGarden.Components
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