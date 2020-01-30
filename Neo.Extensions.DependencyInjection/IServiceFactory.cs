using System;
using System.Collections.Generic;

namespace Neo.Extensions.DependencyInjection
{
    public interface IServiceFactory<TService>
        where TService : class
    {
        IServiceFactory<TService> AddService<TDerivedResult>(string key) where TDerivedResult : TService;
        IServiceFactory<TService> AddService<TDerivedResult>() where TDerivedResult : TService;
        TService WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class;
        TService WithOption(string key);
        IEnumerable<TService> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class;
        IEnumerable<TService> WithOption(IEnumerable<string> keys);
    }

    public interface IServiceFactory<TService1, TService2>
        where TService1 : class
        where TService2 : class
    {
        IServiceFactory<TService1, TService2> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2;
        IServiceFactory<TService1, TService2> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2;
        (TService1, TService2) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class;
        (TService1, TService2) WithOption(string key);
        IEnumerable<(TService1, TService2)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class;
        IEnumerable<(TService1, TService2)> WithOption(IEnumerable<string> keys);
    }

    public interface IServiceFactory<TService1, TService2, TService3>
        where TService1 : class
        where TService2 : class
        where TService3 : class
    {
        IServiceFactory<TService1, TService2, TService3> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3;
        IServiceFactory<TService1, TService2, TService3> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3;
        (TService1, TService2, TService3) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class;
        (TService1, TService2, TService3) WithOption(string key);
        IEnumerable<(TService1, TService2, TService3)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class;
        IEnumerable<(TService1, TService2, TService3)> WithOption(IEnumerable<string> keys);
    }

    public interface IServiceFactory<TService1, TService2, TService3, TService4>
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
    {
        IServiceFactory<TService1, TService2, TService3, TService4> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3, TService4;
        IServiceFactory<TService1, TService2, TService3, TService4> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3, TService4;
        (TService1, TService2, TService3, TService4) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class;
        (TService1, TService2, TService3, TService4) WithOption(string key);
        IEnumerable<(TService1, TService2, TService3, TService4)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class;
        IEnumerable<(TService1, TService2, TService3, TService4)> WithOption(IEnumerable<string> keys);
    }

    public interface IServiceFactory<TService1, TService2, TService3, TService4, TService5>
        where TService1 : class
        where TService2 : class
        where TService3 : class
        where TService4 : class
        where TService5 : class
    {
        IServiceFactory<TService1, TService2, TService3, TService4, TService5> AddService<TDerivedResult>(string key) where TDerivedResult : TService1, TService2, TService3, TService4, TService5;
        IServiceFactory<TService1, TService2, TService3, TService4, TService5> AddService<TDerivedResult>() where TDerivedResult : TService1, TService2, TService3, TService4, TService5;
        (TService1, TService2, TService3, TService4, TService5) WithOption<TOptions>(Func<TOptions, string> keySelector) where TOptions : class;
        (TService1, TService2, TService3, TService4, TService5) WithOption(string key);
        IEnumerable<(TService1, TService2, TService3, TService4, TService5)> WithOption<TOptions>(Func<TOptions, IEnumerable<string>> keySelector) where TOptions : class;
        IEnumerable<(TService1, TService2, TService3, TService4, TService5)> WithOption(IEnumerable<string> keys);
    }
}