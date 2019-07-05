namespace MononokeEngine.Physics.Colliders
{
    public class BoxCollider : Collider
    {
 
        // TODO calculate positions with offsets
        
        public override float Top => this.Position.Y;
        
        public override float Bottom => this.Position.Y + Height;
        public override float Left => this.Position.X;
        public override float Right => this.Position.X + Width;

        public BoxCollider(float width, float height)
        {
            Width = width;
            Height = height;
        }
    }
}