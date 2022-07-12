using Domain.Common;
using Domain.Entitis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class KursyWalutDbContext : DbContext
    {
        public KursyWalutDbContext(DbContextOptions options) : base(options) {   }

        public DbSet<Rate> Rates { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(e => e.Entity is AuditableEntity && e.State == EntityState.Added);

            foreach(var entity in entities)
            {
                ((Rate)entity.Entity).DownloadDate = DateTime.Now;
            }

            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>().Property(r => r.RateValue).HasPrecision(18, 4);
        }
    }
}
