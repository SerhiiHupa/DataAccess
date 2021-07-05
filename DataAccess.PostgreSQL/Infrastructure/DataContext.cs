using System.Linq;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.PostgreSQL.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=postgres;Username=postgres;Password=password;");
         }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(x =>
            {
                x.State = EntityState.Detached;
            });
        }
    }
}
