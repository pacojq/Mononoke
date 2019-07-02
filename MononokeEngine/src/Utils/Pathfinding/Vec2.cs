using Microsoft.Xna.Framework;

namespace MononokeEngine.Utils.Pathfinding
{
    public class Vec2
    {
        public int X
        {
            get => (int) _vec.X;
            set => _vec.X = value;
        }
        
        public int Y
        {
            get => (int) _vec.Y;
            set => _vec.Y = value;
        }

        
        
        public static bool operator ==(Vec2 a, Vec2 b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        
        public static bool operator !=(Vec2 a, Vec2 b)
        {
            return !(a == b);
        }
        
        
        
        
        private Vector2 _vec;
        
        public Vec2(int x, int y)
        {
            _vec = new Vector2(x, y);
        }
        
        public Vec2(Vector2 vec)
        {
            _vec = vec;
        }
        

    }
}