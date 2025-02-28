using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClickLogService
    {
        private readonly IClickLogRepository _clickLogRepository;

        public ClickLogService(IClickLogRepository clickLogRepository)
        {
            _clickLogRepository = clickLogRepository;
        }

        public Dictionary<string, int> GetBrowserStatistics(string shortCode)
        {
            return _clickLogRepository.GetBrowserStatistics(shortCode);
        }
    }
}
