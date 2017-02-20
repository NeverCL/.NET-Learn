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
    - 



