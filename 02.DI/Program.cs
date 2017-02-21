using System;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // 注册泛型接口实现
            serviceCollection.AddScoped(typeof(IFoo<>), typeof(Foo<>));
            serviceCollection.AddTransient(typeof(IFoo<>), typeof(Foo<>));
            // 以最后一次注册类型为准
            serviceCollection.AddSingleton(typeof(IFoo<>), typeof(Foo<>));
            // 根据ServiceCollection生成ServiceProvider
            var provider = serviceCollection.BuildServiceProvider();
            // 获取实例
            provider.GetService(typeof(IFoo<string>));
            // 获取子scope的provider
            var scope = provider.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<IFoo<string>>();

            Console.ReadKey();
        }
    }

    public interface IFoobar : IDisposable
    { }

    public class Foobar : IFoobar
    {
        ~Foobar()
        {
            Console.WriteLine("Foobar.Finalize()");
        }

        public void Dispose()
        {
            Console.WriteLine("Foobar.Dispose()");
        }
    }

    public class Foo<T> : IFoo<T>
    {
        public Foo()
        {
            System.Console.WriteLine("Foo执行构造函数");
        }
    }

    public interface IFoo<T>
    {

    }
}
