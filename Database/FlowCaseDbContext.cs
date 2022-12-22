using FlowCaseTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowCaseTracking.Database
{
    public class FlowCaseDbContext: DbContext
    {
        public FlowCaseDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
