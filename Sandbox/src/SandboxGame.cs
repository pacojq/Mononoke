using System;
using Microsoft.Xna.Framework;
using Mononoke;
using Mononoke.Core;
using Sandbox.Scenes;

namespace Sandbox
{
    public class SandboxGame : MnkGame
    {
        
        public const int ScreenWidth = 640;
        public const int ScreenHeight = 320;
        
        public SandboxGame() :
            base(ScreenWidth, ScreenHeight, ScreenWidth, ScreenHeight, "Mononoke Sandbox", false)
        {
            
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            LoadScene(new Scene1());
        }
        
        protected override void LoadContent()
        {
            base.LoadContent();
            
            Console.WriteLine("Load content");
            
            // TODO: use this.Content to load your game content here
            
        }
    }
}