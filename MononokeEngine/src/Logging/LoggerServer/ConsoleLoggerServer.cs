using System;
#if DEBUG
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;
#endif

namespace MononokeEngine.Logging
{
    public class ConsoleLoggerServer : ILogger
    {

        public static readonly int Port = 8191;
        
#if DEBUG

        private TcpChannel _serverChannel;

        private bool _open;
        
        private LoggerProxy _proxy;
        
        internal ConsoleLoggerServer()
        {
            _serverChannel = new TcpChannel(Port);
        }
        
        
        [SecurityPermission(SecurityAction.Demand)]
        public void Open()
        {
            if (_open)
                return;
            
            ChannelServices.RegisterChannel(_serverChannel, true);
            _open = true;
            
            // Show info
            Console.WriteLine("The name of the channel is {0}.", _serverChannel.ChannelName);
            Console.WriteLine("The priority of the channel is {0}.", _serverChannel.ChannelPriority);

            // Show the URIs associated with the channel.
            ChannelDataStore data = (ChannelDataStore) _serverChannel.ChannelData;
            foreach (string uri in data.ChannelUris)
            {
                Console.WriteLine("The channel URI is {0}.", uri);
            }

            
            // Expose an object for remote calls.
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(LoggerProxy), "LoggerProxy.rem", 
                WellKnownObjectMode.Singleton);

            _proxy = (LoggerProxy) Activator.GetObject(typeof(LoggerProxy), "tcp://localhost:9090/LoggerProxy.rem");

            // Parse the channel's URI.
            string[] urls = _serverChannel.GetUrlsForUri("LoggerProxy.rem");
            if (urls.Length > 0)
            {
                string objectUrl = urls[0];
                string objectUri;
                string channelUri = _serverChannel.Parse(objectUrl, out objectUri);
                Console.WriteLine("The object URL is {0}.", objectUrl);
                Console.WriteLine("The object URI is {0}.", objectUri);
                Console.WriteLine("The channel URI is {0}.", channelUri);
            }

        }
#endif


        public void Close()
        {
            if (!_open)
                return;
            
            ChannelServices.UnregisterChannel(_serverChannel);
            _open = false;
        }
        
        
        
        public void Print(string msg)
        {
#if DEBUG
            _proxy.Enqueue(msg);
#endif
        }
    }
}