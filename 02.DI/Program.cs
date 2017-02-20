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
            serviceCollection.AddTransient(typeof(IFoo<>),typeof(Foo<>));
            var provider = serviceCollection.BuildServiceProvider();
            provider.GetService(typeof(IFoo<string>));
            Console.ReadKey();
        }
    }

    public class Foo<T> : IFoo<T>
    {
        public Foo()
        {
            System.Console.WriteLine("Foo执行构造函数");
        }
    }

    public interface IFoo<T1>
    {

    }
}
