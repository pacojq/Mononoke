using MononokeEngine.Components;
using MononokeEngine.ECS;

namespace MononokeEngine.Systems
{
    public class RenderingSystem : EcsSystem<IRenderizableComponent>
    {
        protected override void UpdateEntity(IRenderizableComponent entity)
        {
            entity.Render();
        }
    }
    
    
    
}