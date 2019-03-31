using System;
using Mononoke.Components;
using Mononoke.ECS;

namespace Mononoke.Systems
{
    public class RenderingSystem : Core.System<RenderingSystem.Filter>
    {

        public struct Filter
        {
            public IRenderizableComponent Renderizable;
        }



        protected override void UpdateEntity(Filter e)
        {
            e.Renderizable.Render();
        }
    }
    
    
    
}