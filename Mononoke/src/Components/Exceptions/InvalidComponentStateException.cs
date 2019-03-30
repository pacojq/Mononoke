using System;

namespace Mononoke.Components.Exceptions
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