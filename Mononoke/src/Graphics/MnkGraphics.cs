using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mononoke.Core;
using Mononoke.Utils;

namespace Mononoke.Graphics
{
    public static class MnkGraphics
    {
       
        public static SpriteBatch SpriteBatch { get; private set; }
        public static SpriteFont DefaultFont { get; private set; }



        internal static void Initialize(GraphicsDevice graphicsDevice)
        {
            SpriteBatch = new SpriteBatch(graphicsDevice);
            DefaultFont = MnkGame.Instance.Content.Load<SpriteFont>(@"Mononoke\MononokeDefault");
            
            Console.WriteLine("MnkGraphics initialized!");
        }

        

    }
}