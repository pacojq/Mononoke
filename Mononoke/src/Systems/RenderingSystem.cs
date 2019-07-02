
using Mononoke.Components;
using Mononoke.Core;

namespace Mononoke.Systems
{
    public class RenderingSystem : EcsSystem<IRenderizableComponent>
    {
        protected override void UpdateEntity(IRenderizableComponent entity)
        {
            entity.Render();
        }
    }
    
    
    
}