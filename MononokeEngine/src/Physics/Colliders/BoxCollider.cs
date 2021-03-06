using Microsoft.Xna.Framework;
using MononokeEngine.Scenes;

namespace MononokeEngine.Physics.Colliders
{
    public class BoxCollider : Collider
    {
 
        // TODO calculate positions with offsets
        
        public override float Top => this.Position.Y;
        
        public override float Bottom => this.Position.Y + Height;
        public override float Left => this.Position.X;
        public override float Right => this.Position.X + Width;
        

        public BoxCollider(float width, float height, Vector2 center) : base(center)
        {
            Width = width;
            Height = height;
        }
        
        public BoxCollider(float width, float height) 
            : this(width, height, Vector2.Zero) { }
        
        
        
        
        
        
        
        internal override void DebugDraw()
        {
            if (!Entity.Active)
                return;
            
            Color col = Color.Red;
            if (!Entity.Collidable)
                col = Color.Gray;
            
            Mononoke.Graphics.Draw.RectExt(Position.X-2, Position.Y-2, 4, 4, col, false);
            Mononoke.Graphics.Draw.RectExt(Left, Top, Width, Height, col, true);
        }
        
        
        internal override bool IsOnCameraBounds(Camera camera)
        {
            float x = camera.Position.X;
            float y = camera.Position.Y;
        
            if (Left > x + camera.Width)
                return false;
        
            if (Top > y + camera.Height)
                return false;
        
            if (Right < x)
                return false;
        
            if (Bottom < y)
                return false;

            return true;
            
        }
    }
}