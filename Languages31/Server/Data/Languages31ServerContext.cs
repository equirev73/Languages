using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Languages31.Shared;

namespace Languages31.Server.Data
{
    public class Languages31ServerContext : DbContext
    {
        public Languages31ServerContext (DbContextOptions<Languages31ServerContext> options)
            : base(options)
        {
        }

        public DbSet<Languages31.Shared.ProgramingLanguages> ProgramingLanguages { get; set; }
    }
}
