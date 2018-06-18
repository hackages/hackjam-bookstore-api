# HackJam ASP.NET Core Bookstore api
During this Hackjam you'll learn the basics of ASP.Net core application development !

## A quick history before you start
End June 2016, Microsoft announces the release of its new open-source and cross-platform Web application development framework, ASP.NET Core 1.0.

This one is part of the rewriting of the entire .Net Framework under open-source license, named .Net Core...

ASP.NET Core is more scalable, more powerful and especially multiplatform! (more info [here](https://docs.microsoft.com/en/aspnet/core/choose-aspnet-framework))

The current version of ASP.NET Core is version 2.1.

## To get started
```Bash
git clone https://github.com/hackages/hackjam-bookstore-api.git
cd hackjam-bookstore-api/BookstoreWebApi
dotnet run
```

## What you need to know...

### [Program.cs](https://docs.microsoft.com/en/aspnet/core/fundamentals/?view=aspnetcore-2.0&tabs=aspnetcore2x)
The basic template when creating a Net Core application contains a "Program" class.
This class provides the "Main" method, entry point of our application...

An ASP.Net Core application is simply a console application that creates a web server in its "Main" method.

Here is a basic example of how to create a web server.

```csharp
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace aspnetcoreapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
```

### [Startup.cs](https://docs.microsoft.com/en/aspnet/core/fundamentals/startup?view=aspnetcore-2.0)
The "Startup" class is provided to the web server when it is created.
This class configures our web server through two methods "ConfigureServices" and "Configure".

Here is a basic example: 
```csharp
public class Startup
{
    // Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
    }

    // Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
        ...
    }
}
```


#### ConfigureServices()
This method receives an instance of "IServiceCollection" as parameter.
"IServiceCollection" is the class that defines the services to be used in the application.
If we want to configure our application to use the MVC framework, we just need to add the following line :

```csharp
// Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddMvc();
        ...
    }
```
##### [Dependency Injection](https://docs.microsoft.com/en/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.0)
Asp.Net Core contains a built-in dependency injection system.
We can therefore register dependencies that will be injected throughout the entire application life cycle.

Example : Registration of "MyBusiness" class within the system:
```csharp
// Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddScoped<IMyBusiness, MyBusiness>();
        ...
    }
```

#### Configure()
The "Configure" method allows to define a middleware pipeline that all requests will traverse.

For example, "MVC" is a middleware that has to be defined in this method.

```csharp
// Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseMvC();
    }
```
When the request reaches the MVC middleware, it will be redirected to the right controller and action to execute.

### [Routing](https://docs.microsoft.com/en/aspnet/core/fundamentals/routing?view=aspnetcore-2.0)


## What to do ?
An Asp.Net Core application is available. The application was ~~viciously~~ broken by me.
Your mission is to make it work again and thus allow communication with a client application.

## Bonus
Implement the creation of a "Book" entity through a "Post" call to the "BooksController".
