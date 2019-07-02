using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGarden.Core;
using MonoGarden.Graphics;

namespace MonoGarden.Components.Graphics
{
    public class TextRenderer : Component, IRenderizableComponent
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
        
        
        
        public void Render()
        {
            MnkGraphics.SpriteBatch.DrawString(Font, Text, Position, Color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0);
        }
    }
}