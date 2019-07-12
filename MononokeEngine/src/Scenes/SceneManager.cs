namespace MononokeEngine.Scenes
{
    public class SceneManager
    {
        public Scene Current { get; private set; }
        
        internal void Initialize()
        {
            
        }
        
        public void Load(Scene scene)
        {
            // TODO loading and unloading stuff
            Current = scene;
        }
    }
}