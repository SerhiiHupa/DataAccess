using NUnit.Framework;
using DataAccess.Unified.IntegrationTests.CRUD;

namespace DataAccess.MongoDB.IntegrationTests.CRUD
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
        public static void TearDown()
        {
            ClearDatabaseHelper.Clear();
        }
    }
}
