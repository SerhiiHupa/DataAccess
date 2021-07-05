using System;
using System.Linq.Expressions;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.Models
{
    public class TestEntityPredicateProvider : IPredicateProvider<TestEntity>
    {
        public Expression<Func<TestEntity, bool>> Get(TestEntity entity)
        {
            return x => x.TestPropertyInt == entity.TestPropertyInt && x.TestPropertyString == entity.TestPropertyString;
        }
    }
}