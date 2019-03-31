namespace Mononoke.ECS
{
    public interface IComponent
    {
        
        IEntity Entity { get; set; }


        void Update();


        void OnBinding(IEntity entity);
        
        void OnUnbinding(IEntity entity);
        
    }
}