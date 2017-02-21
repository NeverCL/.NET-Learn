# .NET-Learn

## 01. Hello World

- dotnet 命令
    - mkdir hwapp --创建目录hwapp
    - cd hwapp --打开目录hwapp
    - dotnet new --创建项目(Program.cs + project.json)
        - dotnet new -t web --创建Web项目
    - dotnet restore --还原依赖(project.lock.json)
    - dotnet run --运行项目(执行bin\debug\projectName.dll)

- dotnet 文件格式
    - project.json  --dotnetcore project files(类似csproject)
    - *.xproj       --通过vs打开dotnetcore 项目,会自动生成该文件


## 02. DI

- IServiceProvider
    - 该接口提供唯一的方法GetService()
    - Core的实现为ServiceProvider
    - 通过IServiceCollection的BuildServiceProvider()获取实现

- ServiceDescriptor
    - 保存待实例化的接口和实现的关系,包括生命周期
    - 生命周期:Singleton,Scoped,Transient

- 服务的注册与获取
    - 注册:本质就是添加ServiceDescriptor对象
    - 获取:通过IServiceProvider接口即可获取对象

- 注册泛型
    - 例子:serviceCollection.AddTransient(typeof(IFoo<>),typeof(Foo<>));
    - 例子:serviceCollection.AddTransient(typeof(IFoo<,>),typeof(Foo<,>));

- 构造函数的选择
    - 每一个候选构造函数的参数类型集合都是这个构造函数参数类型集合的子集.

- 生命周期管理
    - Singleton：ServiceProvider创建的服务实例保存在作为根节点的ServiceProvider上，所有具有同一根节点的所有ServiceProvider提供的服务实例均是同一个对象。
    - Scoped：ServiceProvider创建的服务实例由自己保存，所以同一个ServiceProvider对象提供的服务实例均是同一个对象。
    - Transient：针对每一次服务提供请求，ServiceProvider总是创建一个新的服务实例。

- 服务实例的回收
    - Singleton：由作为根的ServiceProvider负责，后者的Dispose方法被调用的时候，这些服务实例的Dispose方法会自动执行。
    - Scope或者Transient：ServiceProvider自行承担由它提供的服务实例的回收工作，当它的Dispose方法被调用的时候，这些服务实例的Dispose方法会自动执行。


## 03. 文件系统FileProvider

