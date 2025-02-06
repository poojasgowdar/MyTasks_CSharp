using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkMigration.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
