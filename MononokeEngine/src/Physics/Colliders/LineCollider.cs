using System;

namespace MononokeEngine.Physics.Colliders
{
    public class LineCollider : Collider
    {
        /// <summary>
        /// The X position of the end of the line.
        /// </summary>
        public float X2;

        /// <summary>
        /// The Y position of the end of the line.
        /// </summary>
        public float Y2;
        
        
        public override float Width => Math.Abs(Position.X - X2);

        public override float Height => Math.Abs(Position.Y - Y2);
        internal override void DebugDraw()
        {
            throw new NotImplementedException();
        }
    }
}