using Entities.Entities;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ClickLogRepository: IClickLogRepository
    {
        private readonly LinkTrackingDbContext _context;

        public ClickLogRepository(LinkTrackingDbContext context)
        {
            _context = context;
        }
        public void AddClickLog(ClickLog clickLog)
        {
            _context.ClickLogs.Add(clickLog);
            _context.SaveChanges();
        }
        public IEnumerable<ClickLog> GetLogsByShortCode(string shortCode) =>
            _context.ClickLogs.Where(c => c.ShortCode == shortCode).ToList();
        public Dictionary<string, int> GetBrowserStatistics(string shortCode)
        {
            return _context.ClickLogs
                .Where(c => c.ShortCode == shortCode)
                .GroupBy(c => c.Browser ?? "Unknown")
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
