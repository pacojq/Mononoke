using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Mononoke.ECS
{
    public interface IEntity
    {
        
        
        Vector2 Position { get; set; }




        
        IEnumerable<IComponent> Components { get; }
        
        void Bind(IComponent component);

        void Unbind(IComponent component);
        
        T GetComponent<T>() where T : IComponent;
        
        
    }
}