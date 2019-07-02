namespace MononokeEngine.ECS
{
    public interface ISystem
    {
        
        bool Accept(Entity entity);

        void Update();
    }
}