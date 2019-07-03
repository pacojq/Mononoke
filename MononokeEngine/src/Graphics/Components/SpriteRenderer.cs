using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics.Components
{
    public class SpriteRenderer : Graphic
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
        
        
        
        public override void Render()
        {
            if (Sprite == null)
                return;

            Mononoke.Graphics.SpriteBatch.Draw(
                Sprite.Texture, 
                Position, 
                Sprite.ClipRect, 
                Color.White, 
                Rotation,
                Vector2.Zero, // TODO origin
                Scale, 
                Flip, 
                0);
        }
    }
}