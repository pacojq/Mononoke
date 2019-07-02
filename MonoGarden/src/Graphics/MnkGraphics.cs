using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGarden.Core;
using MonoGarden.Utils;

namespace MonoGarden.Graphics
{
    public class MnkGraphics
    {
       
        public static GraphicsDevice GraphicsDevice { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static SpriteFont DefaultFont { get; private set; }


        private static MnkGraphics _instance;
        
        

        internal static void Initialize(GraphicsDevice graphicsDevice)
        {
            if (_instance == null)
                _instance = new MnkGraphics(graphicsDevice);
        }


        private MnkGraphics(GraphicsDevice graphicsDevice)
        {
            SpriteBatch = new SpriteBatch(graphicsDevice);
            DefaultFont = MnkGame.Instance.Content.Load<SpriteFont>(@"MonoGarden\MononokeDefault");
            
            Console.WriteLine("MnkGraphics initialized!");
        }




        
        
        
        public static SpriteAtlas LoadAtlas(string path)
        {
            // TODO
            XmlDocument xml = new XmlDocument();
            xml.Load(TitleContainer.OpenStream(Path.Combine(MnkGame.Instance.Content.RootDirectory, path)));
           
            XmlElement xmlAtlas = xml["atlas"];
            List<Sprite> textures = new List<Sprite>();
            
            foreach (XmlElement tex in xmlAtlas)
            {
                var texturePath = tex.GetAttribute("path");
                string fsloc = MnkGame.ContentDirectory +"\\"+ Path.GetDirectoryName(path) + texturePath + ".png";
                
                var fileStream = new FileStream(fsloc, FileMode.Open, FileAccess.Read);
                var texture = Texture2D.FromStream(MnkGame.Instance.GraphicsDevice, fileStream);
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
            string texPath = Path.Combine(MnkGame.ContentDirectory, path) + ".png";
            var fileStream = new FileStream(texPath, FileMode.Open, FileAccess.Read);
            Texture2D texture = Texture2D.FromStream(MnkGame.Instance.GraphicsDevice, fileStream);
            fileStream.Close();
            return new Sprite(texture);
        }
        
    }
}