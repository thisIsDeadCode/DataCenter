using System.Collections.Generic;

namespace DataCenter
{
    public class Server
    {
        public int IndexServer { get; set; }
        public Status Status { get; set; }

        public Server(int indexServer)
        {
            IndexServer = indexServer;
            Status = Status.Active;
        }

        public void Disable()
        {
            Status = Status.Disable;
        }

        public void Reset()
        {
            Status = Status.Reset;
        }
    }
}
