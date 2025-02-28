using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public void LogClick(string shortCode, ClickLog log)
    {
        var shortLink = _context.ShortLinks.FirstOrDefault(s => s.ShortCode == shortCode);
        if (shortLink == null)
        {
            throw new InvalidOperationException("ShortLink not found for the provided ShortCode.");
        }

        log.ShortLink = shortLink; // Assign the ShortLink object
        _context.ClickLogs.Add(log);
        _context.SaveChanges();
    }


}
