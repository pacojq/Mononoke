using Mononoke.Core;

namespace Mononoke.ECS
{
    public interface ISystem
    {
        
        bool Accept(IEntity entity);

        void Update();
    }
}