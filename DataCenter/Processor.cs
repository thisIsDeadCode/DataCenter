using Microsoft.AspNetCore.Hosting.Server;
using System.Collections.Generic;
using System.Linq;

namespace DataCenter
{
    public class Processor
    {
        private int q; // число дата центров
        private int n; // число серверов
        private int m; // количество событий

        private string resultStr = string.Empty; 

        private List<DataCenter> DataCenters = new List<DataCenter>();

        public Processor(int q, int n, int m)
        {
            this.q = q;
            this.n = n;
            this.m = m;

            for(int i = 1; i <= q; i++)
            {
                DataCenters.Add(new DataCenter(i, n));
            }
        }

        public void Disable(int i, int j)
        {
            var dataCenter = DataCenters.FirstOrDefault(x => x.IndexDataCenter == i);
            dataCenter.DisableServer(j);
        }

        public void Reset(int i)
        {
            var dataCenter = DataCenters.FirstOrDefault(x => x.IndexDataCenter == i);
            dataCenter.ResetServers();
        }

        public int GETMAX()
        {
            List<(DataCenter, int)> result = new List<(DataCenter, int)>();

            foreach(var dataCenter in DataCenters)
            {
                result.Add((dataCenter, dataCenter.GetR_A()));
            }

            var max = result.Max(x => x.Item2);

            result = result.Where(x => x.Item2 == max).ToList();

            int indexDatacenter = 0;
            if(result.Count() > 1)
            {
                var min = result.Min(x => x.Item1.IndexDataCenter);
                indexDatacenter = result.FirstOrDefault(x => x.Item1.IndexDataCenter == min).Item1.IndexDataCenter;
            }
            else
            {
                indexDatacenter = result.FirstOrDefault().Item1.IndexDataCenter;
            }

            resultStr += $"\n{indexDatacenter}";

            return indexDatacenter;
        }

        public int GETMIN()
        {
            List<(DataCenter, int)> result = new List<(DataCenter, int)>();

            foreach (var dataCenter in DataCenters)
            {
                result.Add((dataCenter, dataCenter.GetR_A()));
            }

            var max = result.Min(x => x.Item2);

            result = result.Where(x => x.Item2 == max).ToList();

            int indexDatacenter = 0;
            if (result.Count() > 1)
            {
                var min = result.Min(x => x.Item1.IndexDataCenter);
                indexDatacenter = result.FirstOrDefault(x => x.Item1.IndexDataCenter == min).Item1.IndexDataCenter;
            }
            else
            {
                indexDatacenter = result.FirstOrDefault().Item1.IndexDataCenter;
            }

            resultStr += $"\n{indexDatacenter}";

            return indexDatacenter;
        }

        public string GetResult()
        {
            return resultStr.Trim();
        }
    }
}
