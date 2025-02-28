using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IShortLinkRepository
    {
        public ShortLink GetByShortCode(string shortCode);
        public void AddShortLink(ShortLink shortLink);
        public void DeleteShortLink(string shortCode);
        public IEnumerable<ShortLink> GetAllShortLinks();
        public void SaveChanges();
    }
}
