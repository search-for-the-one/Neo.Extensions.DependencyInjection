namespace Neo.Extensions.DependencyInjection
{
    public interface IKeyedServiceCollection<in TService> where TService : class
    {
        IKeyedServiceCollection<TService> AddService<TDerivedResult>() where TDerivedResult : TService;
        IKeyedServiceCollection<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService;
        IKeyedServiceCollection<TService> AddService<TDerivedResult>(TDerivedResult derivedResult) where TDerivedResult : TService;
        IKeyedServiceCollection<TService> AddService<TDerivedResult>(string key, TDerivedResult derivedResult) where TDerivedResult : TService;
    }
}