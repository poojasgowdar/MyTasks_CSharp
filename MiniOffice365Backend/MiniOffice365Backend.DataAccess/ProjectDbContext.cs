using Microsoft.EntityFrameworkCore;
using MiniOffice365Backend.DataAccess.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = MiniOffice365Backend.DataAccess.DBModel.File;

namespace MiniOffice365Backend.DataAccess
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<File> Files { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {
        
        }


    }
}
