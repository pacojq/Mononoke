namespace MononokeEngine.ECS
{
    public interface IComponent
    {
        
        bool Active { get; }
        
        bool Visible { get; }
        
        Entity Entity { get; set; }


        void Update();
        
        void Render();
    }
}