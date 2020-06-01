using System.Runtime.Serialization;

namespace MinimalOPCServer
{
    // Configuration of data access node manager
    [DataContract(Namespace = Namespaces.NodeMinimalServer)]
    internal class ServerConfiguration
    {
        // The default constructor.
        public ServerConfiguration()
        {
            Initialize();
        }


        // Initializes the object during deserialization.
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }


        // Sets private members to default values.
        private void Initialize()
        {
        }
    }
}
