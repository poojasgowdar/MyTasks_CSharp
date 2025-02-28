using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ShortLink
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ShortCode { get; set; } = string.Empty;
        public string OriginalUrl { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }

        public ICollection<ClickLog> ClickLogs { get; set; } = new List<ClickLog>();
    }
}
