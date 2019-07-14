using System;
using System.Collections.Generic;

namespace MononokeEngine.Logging
{
    /*
    public class LoggerProxy : MarshalByRefObject
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

        public LoggerProxy()
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
    */
}