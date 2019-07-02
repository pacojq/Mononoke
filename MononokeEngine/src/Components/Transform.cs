using Microsoft.Xna.Framework;
using MononokeEngine.ECS;

namespace MononokeEngine.Components
{
    public struct Transform : IComponent
    {
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;
        
        public Entity Entity { get; set; }
    }
}