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
