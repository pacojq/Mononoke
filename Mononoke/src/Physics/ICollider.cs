using Microsoft.Xna.Framework;
using Mononoke.Components.Colliders;

namespace Mononoke.Physics
{
    public interface ICollider
    {
        float Width { get; }
        float Height { get; }
        
        bool IsTrigger { get; }
        
        float Top { get; }
        float Bottom { get; }
        float Left { get; }
        float Right { get; }
        
        float CenterX { get; }
        float CenterY { get; }
        
        // XNA
        bool Collide(Vector2 point);
        bool Collide(Rectangle rect);
        
        // Mononoke colliders
        bool Collide(BoxCollider other);
        bool Collide(CircleCollider other);
    }
}