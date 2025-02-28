using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class ClickLog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey(nameof(ShortLink))]
        public string ShortCode { get; set; }

        [Required]
        [MaxLength(45)]
        public string IPAddress { get; set; }

        [MaxLength(50)]
        public string? Country { get; set; }

        [MaxLength(100)]
        public string? Region { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(50)]
        public string? Browser { get; set; }

        [MaxLength(50)]
        public string? OS { get; set; }

        public string? Referer { get; set; }

        public DateTime VisitedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public ShortLink ShortLink { get; set; }
    }

}

