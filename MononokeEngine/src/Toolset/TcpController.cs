using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

namespace MononokeEngine.Toolset
{
    public class TcpController
    {

        public static readonly int Port = 8191;
        
        TcpChannel _serverChannel;
        
        [SecurityPermission(SecurityAction.Demand)]
        public TcpController()
        {
            _serverChannel = new TcpChannel(Port);
        }
    }
}