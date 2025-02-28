using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IClickLogRepository
    {
        public void AddClickLog(ClickLog clickLog);
        public IEnumerable<ClickLog> GetLogsByShortCode(string shortCode);
        public Dictionary<string, int> GetBrowserStatistics(string shortCode);
    }
}
