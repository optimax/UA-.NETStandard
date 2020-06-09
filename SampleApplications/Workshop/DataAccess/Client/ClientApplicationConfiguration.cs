using System.Collections.Generic;
using Opc.Ua;

namespace DataAccessClient
{
    public class ClientApplicationConfiguration: ApplicationConfiguration
    {
        public string LastRemoteUrl { get; set; }
        public List<string> RemoteUrls { get; set; }
    }
}
