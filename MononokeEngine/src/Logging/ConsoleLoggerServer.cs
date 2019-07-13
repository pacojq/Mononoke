using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

namespace MononokeEngine.Logging
{
    public class ConsoleLoggerServer : ILogger
    {

        public static readonly int Port = 9090;

        private LoggerProxy _proxy;
        
        internal ConsoleLoggerServer()
        {
            InitChannel();
        }
        
        [SecurityPermission(SecurityAction.Demand)]
        private void InitChannel()
        {
            // Create the server channel.
            TcpChannel serverChannel = new TcpChannel(Port);
            ChannelServices.RegisterChannel(serverChannel, true);

            // Show info
            Console.WriteLine("The name of the channel is {0}.", serverChannel.ChannelName);
            Console.WriteLine("The priority of the channel is {0}.", serverChannel.ChannelPriority);

            // Show the URIs associated with the channel.
            ChannelDataStore data = (ChannelDataStore) serverChannel.ChannelData;
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
            string[] urls = serverChannel.GetUrlsForUri("LoggerProxy.rem");
            if (urls.Length > 0)
            {
                string objectUrl = urls[0];
                string objectUri;
                string channelUri = serverChannel.Parse(objectUrl, out objectUri);
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