using System;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGarden.Core;
using MonoGarden.ECS;
using MonoGarden.Graphics;
using MonoGarden.Input;

namespace MonoGarden
{
	public class MnkGame : Game
    {
        
        
        #region // - - - - - Properties - - - - - //
        
        public static MnkGame Instance { get; private set; }
        
        public static int Width { get; private set; }
        public static int Height { get; private set; }

        // time
        public static float DeltaTime { get; private set; }
        public static float RawDeltaTime { get; private set; }
        
        
        public static string ContentDirectory
        {
#if PS4
            get { return Path.Combine("/app0/", Instance.Content.RootDirectory); }
#elif NSWITCH
            get { return Path.Combine("rom:/", Instance.Content.RootDirectory); }
#elif XBOXONE
            get { return Instance.Content.RootDirectory; }
#else
            get { return Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"Content"/*Instance.Content.RootDirectory*/); }
#endif
        }
        
        #endregion




        #region // - - - - - Fields - - - - - // 

        
        public string Title;       

        public Action OnStart = () => { };
        public Action OnUpdate = () => { };
        public Action OnEnd = () => { };

        
        public float TimeRate = 1f;
        public float FreezeTimer;
        public int FPS;
        private int _fpsCounter = 0;
        private TimeSpan counterElapsed = TimeSpan.Zero;

        private Scene _scene;
        
        
        private GraphicsDeviceManager _graphics;
        

        #endregion
        
        


        public MnkGame(int width, int height, int windowWidth, int windowHeight, string windowTitle, bool fullscreen)
        {
            Instance = this;

            Title = Window.Title = windowTitle;
            Width = width;
            Height = height;
            
            
            _graphics = new GraphicsDeviceManager(this);
            //_graphics.DeviceReset += OnGraphicsReset;
            //_graphics.DeviceCreated += OnGraphicsCreate;
            
            Window.AllowUserResizing = true;
            //Window.ClientSizeChanged += OnClientSizeChanged;

            if (fullscreen)
            {
                _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                _graphics.IsFullScreen = true;
            }
            else
            {
                _graphics.PreferredBackBufferWidth = windowWidth;
                _graphics.PreferredBackBufferHeight = windowHeight;
                _graphics.IsFullScreen = false;
            }
            _graphics.ApplyChanges();
            
            
            Content.RootDirectory = @"Content";
        }
        
        
        


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            
            MnkInput.Initialize();
            MnkEcs.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

            Console.WriteLine("Content: " + this.Content.RootDirectory);
            
            // TODO: use this.Content to load your game content here
            MnkGraphics.Initialize(GraphicsDevice);
            
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            OnEnd();
            
            // TODO: Unload any non ContentManager content here
        }

        
        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO remove this MonoGame autogenerated statement
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update delta time
            RawDeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            DeltaTime = RawDeltaTime * TimeRate;

            
            //Update input
            MnkInput.Update();
            

            // Update scene
            if (FreezeTimer > 0)
                FreezeTimer = Math.Max(FreezeTimer - RawDeltaTime, 0);
            else if (_scene != null)
            {
                _scene.BeforeUpdate();
                _scene.Update();
                _scene.AfterUpdate();
            }

            // User's custom on update method
            OnUpdate();
            
            // MonoGame update
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Render();
            base.Draw(gameTime);
            
            //Frame counter
            _fpsCounter++;
            counterElapsed += gameTime.ElapsedGameTime;
            if (counterElapsed >= TimeSpan.FromSeconds(1))
            {
#if DEBUG
                Window.Title = $"{Title} [{_fpsCounter} fps -  {(GC.GetTotalMemory(false) / 1048576f):F} MB]";
#endif
                FPS = _fpsCounter;
                _fpsCounter = 0;
                counterElapsed -= TimeSpan.FromSeconds(1);
            }
            
        }


        private void Render()
        {
            if (_scene != null)
                _scene.BeforeRender();

            GraphicsDevice.SetRenderTarget(null);
            //GraphicsDevice.Viewport = Viewport;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_scene != null)
            {
                MnkGraphics.SpriteBatch.Begin();
                _scene.Render();
                MnkGraphics.SpriteBatch.End();
                _scene.AfterRender();
            }
        }
        





        public void LoadScene(Scene scene)
        {
            // TODO loading and unloading stuff
            _scene = scene;
        }
        
        
        
    }
}