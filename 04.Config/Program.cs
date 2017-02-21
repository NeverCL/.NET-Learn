using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var source = new Dictionary<string, string>
            {
               {"appId","123"},
               {"appSec","456"},
               {"id","222"},
               {"Sec","333"},
               {"app:id","789"},
               {"app:sec","987"}
            };

            IConfiguration config = new ConfigurationBuilder()
                                    .Add(new MemoryConfigurationSource { InitialData = source })// 添加数据源
                                    .Build();                                                   // 创建配置对象
            // 获取配置项
            Console.WriteLine(config["appId"]);
            Console.WriteLine(config["appSec"]);
            Console.WriteLine(config.GetSection("app")["id"]);
            Console.WriteLine(config.GetSection("app")["sec"]);

            // 自动反射
            // 1. 不区分大小写
            // 2. 对象必须有无参构造函数
            var app = new ServiceCollection().AddOptions().Configure<App>(config).BuildServiceProvider()
            .GetService<IOptions<App>>().Value;
            Console.ReadKey();
        }
    }

    public class App
    {
        public int Id { get; set; }
        public string Sec { get; set; }
        // public App(IConfiguration config)
        // {
        //     Id = int.Parse(config["appId"]);
        //     Sec = config["appSec"];
        // }
    }
}
