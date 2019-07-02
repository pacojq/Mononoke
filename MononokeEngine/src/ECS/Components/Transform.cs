using Microsoft.Xna.Framework;

namespace MononokeEngine.ECS.Components
{
    public class Transform : IComponent
    {
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;

        public bool Active => true;
        public bool Visible => false;
        public Entity Entity { get; set; }
        
        
        public void Update()
        {
            
        }

        public void Render()
        {
            
        }
    }
}