using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using NUnit.Framework;
using DataAccess.MongoDB.CRUD;
using DataAccess.MongoDB.Infrastructure;
using DataAccess.Interfaces.CRUD;
using DataAccess.PredicateInfrastructure;
using DataAccess.Models;
using DataAccess.Unified.IntegrationTests.CRUD;

namespace DataAccess.MongoDB.IntegrationTests.CRUD
{
    [TestFixture]
    public class UpdateOperationTests : UnifiedUpdateOperationTests
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
