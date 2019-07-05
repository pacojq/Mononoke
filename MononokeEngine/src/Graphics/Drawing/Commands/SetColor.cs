using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics.Drawing.Commands
{
    internal class SetColor : IDrawCommand
    {
        private readonly Color _color;
        private readonly Draw _draw;
        
        internal SetColor(Color color, Draw draw)
        {
            _color = color;
            _draw = draw;
        }

        public void Execute()
        {
            _draw.Color = _color;
        }
    }
}