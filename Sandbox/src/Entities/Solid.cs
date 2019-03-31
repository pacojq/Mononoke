using Mononoke.Components.Colliders;
using Mononoke.Components.Graphics;
using Mononoke.Core;
using Mononoke.Physics;

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