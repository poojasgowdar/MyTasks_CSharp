using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class LinkTrackingDbContext:DbContext
    {
        public DbSet<ShortLink> ShortLinks { get; set; }
        public DbSet<ClickLog> ClickLogs { get; set; }

        public LinkTrackingDbContext(DbContextOptions<LinkTrackingDbContext> options)
            : base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortLink>()
                .HasIndex(s => s.ShortCode)
                .IsUnique();

            modelBuilder.Entity<ClickLog>()
                .HasOne(c => c.ShortLink)
                .WithMany(s => s.ClickLogs)
                .HasForeignKey(c => c.ShortCode)
                .HasPrincipalKey(s => s.ShortCode)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
