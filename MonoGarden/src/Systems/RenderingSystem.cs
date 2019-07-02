using System;
using MonoGarden.Components;
using MonoGarden.ECS;

namespace MonoGarden.Systems
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