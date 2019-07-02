using MononokeEngine.Components.Colliders;
using MononokeEngine.ECS;

namespace Sandbox.Entities
{
    public class Solid : Entity
    {
        public Solid()
        {
            //Add(new SpriteRenderer());
            Bind(new BoxCollider(32, 32));
        }
    }
}