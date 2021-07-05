using System;
using System.Collections.Generic;
using DataAccess.PredicateInfrastructure;

namespace DataAccess.Models
{
    public class PredicateProviderFactory : IPredicateProviderFactory
    {
        public IPredicateProvider<T> Get<T>()
        {
            var register = new Dictionary<Type, IPredicateProvider<T>> {
                {typeof(TestEntity), (IPredicateProvider<T>)new TestEntityPredicateProvider()},
                {typeof(TestEntity2), (IPredicateProvider<T>)new TestEntity2PredicateProvider()}
            };

            var result = register[typeof(T)];
            return result;
        }
    }
}