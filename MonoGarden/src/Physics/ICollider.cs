using Microsoft.Xna.Framework;
using MonoGarden.Components.Colliders;

namespace MonoGarden.Physics
{
    public interface ICollider
    {
        float Width { get; }
        float Height { get; }
        
        float Top { get; }
        float Bottom { get; }
        float Left { get; }
        float Right { get; }
        
        float CenterX { get; }
        float CenterY { get; }
        
        // XNA
        bool Collide(Vector2 point);
        bool Collide(Rectangle rect);
        
        // MonoGarden colliders
        bool Collide(BoxCollider other);
        bool Collide(CircleCollider other);
    }
}