using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MononokeEngine.Graphics.Core;
using MononokeEngine.Graphics.Drawing;
using MononokeEngine.Scenes;

namespace MononokeEngine.Graphics
{
    public class GraphicsManager
    {
        
        /// <summary>
        /// A texture which is just a white pixel.
        /// </summary>
        public Sprite Pixel { get; private set; }


        internal GraphicsDevice GraphicsDevice
        {
            get => _graphicsDevice;
            set
            {
                _graphicsDevice = value;
                SpriteBatch = new SpriteBatch(_graphicsDevice);
                Draw = new Draw(GraphicsDevice, SpriteBatch);
                DrawGUI = new Draw(GraphicsDevice, SpriteBatch);
            }
        }

        internal SpriteBatch SpriteBatch { get; private set; }
        public SpriteFont DefaultFont { get; private set; }

        
        /// <summary>
        /// Draw helper.
        /// </summary>
        public Draw Draw { get; private set; }


        /// <summary>
        /// Draw helper for UI.
        /// </summary>
        public Draw DrawGUI { get; private set; }



        public int Width => _viewHandler.Width;
        public int Height => _viewHandler.Height;

        public int ViewWidth => _viewHandler.ViewWidth;

        public int ViewHeight => _viewHandler.ViewHeight;


        public Viewport Viewport => _viewHandler.Viewport;

        public Matrix ScreenMatrix => _viewHandler.ScreenMatrix;

        public bool Fullscreen => _viewHandler.Fullscreen;


        private GraphicsDevice _graphicsDevice;
        private GameRenderer _renderer;
       

        internal GraphicsManager() { }

        internal void Initialize(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = new SpriteBatch(graphicsDevice);
            DefaultFont = MononokeGame.Instance.Content.Load<SpriteFont>(@"Mononoke\MononokeDefault");
            
            _renderer = new GameRenderer();
            
            Draw = new Draw(GraphicsDevice, SpriteBatch);
            Draw.Font = DefaultFont;
            Draw.Color = Color.White;

            DrawGUI.Font = DefaultFont;
            DrawGUI.Color = Color.White;
        }

        
        internal void Open()
        {
            Draw.Open();

            Scene scene = Mononoke.Scenes.Current;
            
            if (scene != null)
                scene.BeforeDraw();

            GraphicsDevice.SetRenderTarget(null);
            
            Mononoke.Logger.Print($"Viewport: {Viewport}");
            GraphicsDevice.Viewport = Viewport;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (scene != null)
            {
                scene.Draw();
                scene.AfterDraw();
            }


            Draw.Close();
        }

        internal void Render()
        {
            Scene scene = Mononoke.Scenes.Current;
            if (scene == null)
                return;
            
            SpriteBatch.Begin();
            
            _renderer.Render();
            
            SpriteBatch.End();

            _renderer.CleanUp();
        }
        
        internal void Close()
        {
            Draw.Close();
        }
        
        
        
        
        
        


        
        
        
        public static SpriteAtlas LoadAtlas(string path)
        {
            // TODO
            XmlDocument xml = new XmlDocument();
            xml.Load(TitleContainer.OpenStream(Path.Combine(MononokeGame.Instance.Content.RootDirectory, path)));
           
            XmlElement xmlAtlas = xml["atlas"];
            List<Sprite> textures = new List<Sprite>();
            
            foreach (XmlElement tex in xmlAtlas)
            {
                var texturePath = tex.GetAttribute("path");
                string fsloc = Mononoke.ContentDirectory + "\\" + Path.GetDirectoryName(path) + texturePath + ".png";
                
                var fileStream = new FileStream(fsloc, FileMode.Open, FileAccess.Read);
                var texture = Texture2D.FromStream(MononokeGame.Instance.GraphicsDevice, fileStream);
                fileStream.Close();
                
                // TODO get all sprites data from texture
                // Right now, we're just loading the whole texture as an sprite.
                // We should loop through all the declared sprites in the xml.
                
                textures.Add(new Sprite(texture));
            }

            return new SpriteAtlas(textures);
        }
        
        
        /// <summary>
        /// Loads a raw PNG image from the Content directory as a Sprite.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Sprite LoadSprite(string path)
        {
            string texPath = Path.Combine(Mononoke.ContentDirectory, path) + ".png";
            var fileStream = new FileStream(texPath, FileMode.Open, FileAccess.Read);
            Texture2D texture = Texture2D.FromStream(MononokeGame.Instance.GraphicsDevice, fileStream);
            fileStream.Close();
            return new Sprite(texture);
        }
        
    }
}