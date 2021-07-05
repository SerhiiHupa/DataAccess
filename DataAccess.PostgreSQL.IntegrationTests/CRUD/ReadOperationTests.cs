using DataAccess.Unified.IntegrationTests.CRUD;
using NUnit.Framework;

namespace DataAccess.PostgreSQL.IntegrationTests.CRUD
{
    [TestFixture]
    public class ReadOperationTests : UnifiedReadOperationTests
    {
        [SetUp]
        public void SetUp()
        {
            SetUpHelper.SetUp(this);
        }

        [TearDown]
        public void TearDown()
        {
            ClearDatabaseHelper.Clear();
        }
    }
}
