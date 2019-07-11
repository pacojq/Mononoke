using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics.Components
{
    public class SpriteRenderer : GraphicComponent
    {
        public Sprite Sprite;

        public Rectangle ClipRect;

        public float Rotation;

        public Vector2 Scale;

        public SpriteEffects Flip;
        
        
        
        public SpriteRenderer(Sprite sprite)
        {
            Sprite = sprite;
            ClipRect = new Rectangle(0, 0, sprite.Width, sprite.Height);
            Scale = Vector2.One;
            Rotation = 0;
            Flip = SpriteEffects.None;
        }
        
        
        
        protected override void Draw()
        {
            if (Sprite == null)
                return;

            Mononoke.Graphics.Draw.SpriteExt(Sprite, Position, Color.White, Rotation, Vector2.Zero, Scale, Flip, 0);
        }
        
        
        public override bool IsOnCameraBounds(Camera camera)
        {
            float x = camera.Position.X;
            float y = camera.Position.Y;
        
            if (Position.X > x + camera.Width)
                return false;
        
            if (Position.Y > y + camera.Height)
                return false;
        
            if (Position.X + Sprite.Width < x )
                return false;
        
            if (Position.Y + Sprite.Height < y)
                return false;

            return true;
            
        }
    }
}