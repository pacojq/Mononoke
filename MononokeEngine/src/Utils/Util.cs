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
    }
}