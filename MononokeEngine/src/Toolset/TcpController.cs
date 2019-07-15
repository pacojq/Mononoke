using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;
using MononokeEngine.Logging;
using MononokeEngine.Toolset.Logging;

namespace MononokeEngine.Toolset
{
    public class TcpController
    {

        public static readonly int Port = 8191;

        public TcpChannel ServerChannel { get; }
        
        
        
        [SecurityPermission(SecurityAction.Demand)]
        internal TcpController()
        {
            ServerChannel = new TcpChannel(Port);
            InitChannel();
        }
        
        
        private void InitChannel()
        {
            ChannelServices.RegisterChannel(ServerChannel, true);
            
            // Show info
            Console.WriteLine("The name of the channel is {0}.", ServerChannel.ChannelName);
            Console.WriteLine("The priority of the channel is {0}.", ServerChannel.ChannelPriority);

            // Show the URIs associated with the channel.
            ChannelDataStore data = (ChannelDataStore) ServerChannel.ChannelData;
            foreach (string uri in data.ChannelUris)
            {
                Console.WriteLine("The channel URI is {0}.", uri);
            }
        }




        public void RegisterWellKnownServiceType(Type type, string uri)
        {
            // Expose an object for remote calls.
            RemotingConfiguration.RegisterWellKnownServiceType(type, uri, WellKnownObjectMode.Singleton);
            
            Console.WriteLine("New Well Known Service Type registered");
            
            string[] urls = ServerChannel.GetUrlsForUri(uri);
            if (urls.Length > 0)
            {
                string objectUrl = urls[0];
                string channelUri = ServerChannel.Parse(objectUrl, out string objectUri);
                Console.WriteLine("The object URL is {0}.", objectUrl);
                Console.WriteLine("The object URI is {0}.", objectUri);
                Console.WriteLine("The channel URI is {0}.", channelUri);
            }
        }
        
        
        
    }
}