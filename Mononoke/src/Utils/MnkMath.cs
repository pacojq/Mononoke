using System;
using Microsoft.Xna.Framework;

namespace Mononoke.Utils
{
    public static class MnkMath
    {


        public static Vector2 Floor(Vector2 val)
        {
            return new Vector2((int)Math.Floor(val.X), (int)Math.Floor(val.Y));
        }
        
        
        public static int Clamp(int value, int min, int max)
        {
            return Math.Min(Math.Max(value, min), max);
        }

        public static float Clamp(float value, float min, float max)
        {
            return Math.Min(Math.Max(value, min), max);
        }
        
        
    }
}