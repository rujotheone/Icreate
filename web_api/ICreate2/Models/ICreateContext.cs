using Microsoft.EntityFrameworkCore;
using ICreate2.Models;

namespace ICreate2.Models
{
    public class ICreateContext : DbContext
    {
        public ICreateContext(DbContextOptions<ICreateContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<IdeaStatus> IdeaStatus { get; set; }
        public DbSet<IdeaMaster> IdeaMaster { get; set; }
        public DbSet<IdeaType> IdeaType { get; set; }
        public DbSet<IdeaAudittrail> IdeaAudittrail { get; set; }
        public DbSet<Metric> Metric { get; set; }
        public DbSet<BatchHistory> BatchHistory { get; set; }
        public DbSet<IdeaMetric> IdeaMetric { get; set; }

    }
}