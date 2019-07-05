using Microsoft.Xna.Framework;
using SMath = System.Math;

namespace MononokeEngine.Utils
{
    public static class Math
    {
        
        

        public static float PointDirection(Vector2 p0, Vector2 p1)
        {
            return (float) SMath.Atan2(p1.Y - p0.Y, p1.X - p0.X);
        }
        
        public static float PointDistance(Vector2 p0, Vector2 p1)
        {
            return Vector2.Distance(p0, p1);
        }
        
        
        
        
        
        public static Vector2 Floor(Vector2 val)
        {
            return new Vector2((int)SMath.Floor(val.X), (int)SMath.Floor(val.Y));
        }
        
        
        public static int Clamp(int value, int min, int max)
        {
            return SMath.Min(SMath.Max(value, min), max);
        }

        public static float Clamp(float value, float min, float max)
        {
            return SMath.Min(SMath.Max(value, min), max);
        }
        
        
    }
}