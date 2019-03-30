using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mononoke.Core;
using Mononoke.Graphics;

namespace Mononoke.Components.Graphics
{
    public class TextRenderer : Component
    {
        public enum HorizontalAlign { Left, Center, Right };
        public enum VerticalAlign { Top, Center, Bottom };


        public string Text;
        public SpriteFont Font;
        public Color Color;

        public HorizontalAlign HorizontalOrigin;
        public VerticalAlign VerticalOrigin;
        
        
        public TextRenderer(string text, Vector2 position)
        {
            this.Text = text;
            LocalPosition = position;
            Font = MnkGraphics.DefaultFont;
            Color = Color.Black;
            HorizontalOrigin = HorizontalAlign.Left;
            VerticalOrigin = VerticalAlign.Top;
        }
        
        
        
        public override void Render()
        {
            if (MnkGraphics.SpriteBatch == null)
            {
                Console.WriteLine("Null SpriteBatch!");
                return;
            }

            MnkGraphics.SpriteBatch.DrawString(Font, Text, LocalPosition, Color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }
    }
}