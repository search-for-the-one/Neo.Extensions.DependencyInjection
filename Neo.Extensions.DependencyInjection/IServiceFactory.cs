using System;

namespace Neo.Extensions.DependencyInjection
{
    public interface IServiceFactory<TService> where TService : class
    {
        IServiceFactory<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService;
        IServiceFactory<TService> AddService<TDerivedResult>() where TDerivedResult : TService;
        TService WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class, new();
        TService WithOption(string key);
    }
}