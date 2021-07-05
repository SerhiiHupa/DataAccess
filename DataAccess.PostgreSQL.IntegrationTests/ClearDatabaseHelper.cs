using DataAccess.Models;
using DataAccess.PostgreSQL.Infrastructure;

namespace DataAccess.PostgreSQL.IntegrationTests
{
    public static class ClearDatabaseHelper
    {
        public static void Clear()
        {
            var context = new DataContext();
            context.RemoveRange(context.Set<TestEntity>());
            context.SaveChanges();
        }
    }
}
