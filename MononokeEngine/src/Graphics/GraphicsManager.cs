using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MononokeEngine.Graphics
{
    public class GraphicsManager
    {
       
        public GraphicsDevice GraphicsDevice { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public SpriteFont DefaultFont { get; private set; }


       

        internal GraphicsManager()
        {
            
        }

        internal void Initialize(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            SpriteBatch = new SpriteBatch(graphicsDevice);
            DefaultFont = MononokeGame.Instance.Content.Load<SpriteFont>(@"Mononoke\MononokeDefault");
            
            Console.WriteLine("GraphicsManager initialized!");
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
                string fsloc = MononokeGame.ContentDirectory +"\\"+ Path.GetDirectoryName(path) + texturePath + ".png";
                
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
            string texPath = Path.Combine(MononokeGame.ContentDirectory, path) + ".png";
            var fileStream = new FileStream(texPath, FileMode.Open, FileAccess.Read);
            Texture2D texture = Texture2D.FromStream(MononokeGame.Instance.GraphicsDevice, fileStream);
            fileStream.Close();
            return new Sprite(texture);
        }
        
    }
}