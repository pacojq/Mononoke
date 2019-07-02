using MonoGarden.Core;

namespace MonoGarden.ECS
{
    public interface ISystem
    {
        
        bool Accept(IEntity entity);

        void Update();
    }
}