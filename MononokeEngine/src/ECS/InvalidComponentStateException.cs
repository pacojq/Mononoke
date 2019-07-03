using System;

namespace MononokeEngine.ECS
{
    public class InvalidComponentStateException : Exception
    {
        public InvalidComponentStateException() : base()
        {
            
        }

        public InvalidComponentStateException(string msg) : base(msg)
        {
            
        }
    }
}