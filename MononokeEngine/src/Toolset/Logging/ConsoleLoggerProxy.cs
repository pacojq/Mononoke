using System;
using System.Collections.Generic;

namespace MononokeEngine.Toolset.Logging
{

    public class ConsoleLoggerProxy : MarshalByRefObject
    {
        private int _callCount = 0;

        public int GetCount()
        {
            _callCount++;
            return _callCount;
        }


        public int Count
        {
            get
            {
                lock (_locker)
                    return _messages.Count;
            }
        }


        private readonly Queue<string> _messages;
        private readonly object _locker;

        public ConsoleLoggerProxy()
        {
            _messages = new Queue<string>();
            _locker = new object();
        }


        public void Enqueue(string message)
        {
            lock (_locker)
                _messages.Enqueue(message);
        }
        
        public string Dequeue()
        {
            lock (_locker)
                return _messages.Dequeue();
        }
    }
    
}