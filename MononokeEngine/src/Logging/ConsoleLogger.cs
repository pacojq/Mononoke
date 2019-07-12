using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

namespace MononokeEngine.Logging
{
    public class ConsoleLogger : ILogger
    {

        public const int Port = 9090;

        private TcpChannel _serverChannel;
        private LoggerProxy _proxy;
        
        internal ConsoleLogger()
        {
            InitChannel();
        }
        
        [SecurityPermission(SecurityAction.Demand)]
        private void InitChannel()
        {
            // Create the server channel.
            _serverChannel = new TcpChannel(Port);
            ChannelServices.RegisterChannel(_serverChannel, true);

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

        public void Print(string msg)
        {
            _proxy.Enqueue(msg);
        }
    }
}