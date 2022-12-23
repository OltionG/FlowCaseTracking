using FlowCaseTracking.Models;
using Microsoft.EntityFrameworkCore;
using Flow_CaseTracking.Models;

namespace FlowCaseTracking.Database
{
    public class FlowCaseDbContext: DbContext
    {
        public FlowCaseDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Cards> Cards { get; set; }
        public DbSet<Boards> Boards { get; set; }

        public DbSet<Flow_CaseTracking.Models.Boards> Boards { get; set; }

    }
}
