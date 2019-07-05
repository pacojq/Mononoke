using Microsoft.Xna.Framework;

namespace MononokeEngine.Utils
{
    public static class Util
    {
        /// <summary>
        /// Swap two values by reference
        /// </summary>
        /// <param name="a">First value.</param>
        /// <param name="b">Second value.</param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        
        
        
        
        
        public static void Approach(ref Vector2 pos, Vector2 target, float percent)
        {
            pos += (target - pos) * percent;
        }
        
        public static void Approach(ref float n, float target, float percent)
        {
            n += (target - n) * percent;
        }
        
    }
}