using DataAccess.Unified.IntegrationTests.CRUD;
using NUnit.Framework;

namespace DataAccess.MongoDB.IntegrationTests.CRUD
{
    [TestFixture]
    public class CreateOperationTests : UnifiedCreateOperationTests
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
