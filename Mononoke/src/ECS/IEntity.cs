using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Mononoke.ECS
{
    public interface IEntity
    {
        List<IComponent> Components { get; }
        
        Vector2 Position { get; set; }
    }
}