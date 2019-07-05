using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class SetFont : IDrawCommand
    {
        private readonly SpriteFont _font;
        private readonly Draw _draw;
        
        internal SetFont(SpriteFont font, Draw draw)
        {
            _font = font;
            _draw = draw;
        }

        public void Execute()
        {
            _draw.Font = _font;
        }
    }
}