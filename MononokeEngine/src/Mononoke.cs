using System.IO;
using System.Reflection;
using MononokeEngine.ECS;
using MononokeEngine.Graphics;
using MononokeEngine.Input;
using MononokeEngine.Logging;
using MononokeEngine.Scenes;

namespace MononokeEngine
{
    public static class Mononoke
    {

        
        
        public static string ContentDirectory
        {
#if PS4
            get { return Path.Combine("/app0/", Instance.Content.RootDirectory); }
#elif NSWITCH
            get { return Path.Combine("rom:/", Instance.Content.RootDirectory); }
#elif XBOXONE
            get { return MononokeGame.Instance.Content.RootDirectory; }
#else
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Content"); }
#endif
        }
        
        
        
        
        public static SceneManager Scenes
        {
            get
            {
                if (_scenes == null)
                    _scenes = new SceneManager();
                return _scenes;
            }
        }
        private static SceneManager _scenes;
        
        
        
        
        public static EcsManager Ecs
        {
            get
            {
                if (_ecs == null)
                    _ecs = new EcsManager();
                return _ecs;
            }
        }
        private static EcsManager _ecs;
        
        
        
        public static InputManager Input
        {
            get
            {
                if (_input == null)
                    _input = new InputManager();
                return _input;
            }
        }
        private static InputManager _input;
        
        
        
        public static GraphicsManager Graphics
        {
            get
            {
                if (_graphics == null)
                    _graphics = new GraphicsManager();
                return _graphics;
            }
        }
        private static GraphicsManager _graphics;




        public static ILogger Logger
        {
            get
            {
                if (_logger == null)
                    _logger = new ConsoleLogger();
                return _logger;
            }
        }

        private static ILogger _logger;

    }



    
}