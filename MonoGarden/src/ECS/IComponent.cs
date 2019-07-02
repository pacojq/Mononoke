namespace MonoGarden.ECS
{
    public interface IComponent
    {
        
        IEntity Entity { get; set; }


        void OnBinding(IEntity entity);
        
        void OnUnbinding(IEntity entity);
        
    }
}