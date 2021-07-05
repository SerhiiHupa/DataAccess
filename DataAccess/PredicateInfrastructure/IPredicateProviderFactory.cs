namespace DataAccess.PredicateInfrastructure
{
    public interface IPredicateProviderFactory
    {
        IPredicateProvider<T> Get<T>();
    }
}