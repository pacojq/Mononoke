using MononokeEngine.ECS;
using MononokeEngine.Physics.Colliders;

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