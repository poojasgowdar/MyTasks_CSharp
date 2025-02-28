using Entities.Entities;
using Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ShortLinkRepository: IShortLinkRepository
    {
        private readonly LinkTrackingDbContext _context;

        public ShortLinkRepository(LinkTrackingDbContext context)
        {
            _context = context;
        }

        public ShortLink GetByShortCode(string shortCode) =>
            _context.ShortLinks.FirstOrDefault(s => s.ShortCode == shortCode);

        public void AddShortLink(ShortLink shortLink)
        {
            _context.ShortLinks.Add(shortLink);
            _context.SaveChanges();
        }

        public void DeleteShortLink(string shortCode)
        {
            var link = GetByShortCode(shortCode);
            if (link != null)
            {
                _context.ShortLinks.Remove(link);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ShortLink> GetAllShortLinks() =>
            _context.ShortLinks.ToList();

        public void SaveChanges() => _context.SaveChanges();
    }
}
