namespace Mononoke.Graphics
{
    public class Animation
    {
        
        public string Name { get; private set; }
        
        public int FrameCount { get; private set; }
        
        public float Speed;

        private readonly Sprite[] _sprites;
        public Sprite this[int index] => _sprites[index];


        public Animation(Sprite[] sprites, string name, float speed = .1f)
        {
            _sprites = sprites;
            FrameCount = _sprites.Length;
            Name = name;
            Speed = speed;
        }
        
    }
}