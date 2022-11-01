using System.Collections.Generic;
using System.Linq;

namespace DataCenter
{
    public class DataCenter
    {
        public int IndexDataCenter { get; set; }
        public List<Server> Servers { get; set; } = new List<Server>();

        public int R_i; // число перезапусков датацентра
        public int A_i; // число рабочих (не выключенных) серверов на текущий момент в датацентре

        public DataCenter(int indexDataCenter, int amountServers)
        {
            IndexDataCenter = indexDataCenter;

            for(int i = 1; i <= amountServers; i++)
            {
                Servers.Add(new Server(i));
            }

            A_i = amountServers;
            R_i = 0;
        }

        public void DisableServer(int j)
        {
            var server = Servers.FirstOrDefault(x => x.IndexServer == j);
            A_i -= 1;
            server.Disable();
        }

        public void ResetServers()
        {
            foreach(var server in Servers)
            {
                server.Reset();
            }
            R_i += 1;
        }

        public int GetR_A()
        {
            return R_i * A_i;
        }
    }
}
