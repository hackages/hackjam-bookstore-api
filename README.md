# HackJam ASP.NET Core Bookstore api
Durant cet Hackjam vous apprendrez les bases du développement d'applications ASP.NET Core !

## Un rapide historique avant de commencer
Fin Juin 2016, Microsoft annonce la sortie de son tout nouveau framework de développement d'applications Web, open-source et multiplate-forme, ASP.NET Core 1.0.

Celui-ci s'inscrit tout naturellement dans la réécriture de l'entièreté du Framework .Net sous licence open-source, nommé de .Net Core...

ASP.NET Core se veut plus modulable, plus performant et surtout multiplate-formes ! (plus d'infos [ici](https://docs.microsoft.com/fr-fr/aspnet/core/choose-aspnet-framework))

La version actuelle d'ASP.NET Core est la version 2.1.

## Pour commencer
```Bash
git clone https://github.com/hackages/hackjam-bookstore-api.git
cd hackjam-bookstore-api/BookstoreWebApi
dotnet run
```

## Ce qu'il faut savoir...

### [Program.cs](https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/?view=aspnetcore-2.0&tabs=aspnetcore2x)
Le template de base lorsqu'on crée une application .Net Core contient une classe "Program".
Cette classe fournit la méthode "Main", point d'entrée de notre application...

Une application ASP.Net Core est tout simplement une application console qui crée une serveur web dans sa méthode "Main".

Voici un exemple de base de création d'un serveur web.

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

### [Startup.cs](https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/startup?view=aspnetcore-2.0)
La classe "Startup" est fournie au serveur web lors de sa création.
Cette classe configure notre serveur web au travers de deux méthodes "ConfigureServices" et "Configure"

Voici un exemple de base : 
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
Cette méthode reçoit en paramètre une instance de "IServiceCollection".
"IServiceCollection" est la classe qui définit les services que l'on souhaite utiliser dans l'application.
Si l'on souhaite configurer notre application pour utiliser le framework MVC, il nous suffit d'ajouter la ligne suivante :

```csharp
// Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddMvc();
        ...
    }
```
##### [Injection de dépendances](https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.0)
Asp.Net Core contient un système d'injection de dépendance "out of the box".
On peut donc enregistrer des dépendances qui pourront être injecter durant tout le cycle de vie de l'application.

Exemple d'enregistrement de la classe "MonBusiness" au sein du système :
```csharp
// Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddScoped<IMonBusiness, MonBusiness>();
        ...
    }
```

#### Configure()
La méthode "Configure" permet de définir un pipeline de middleware que toutes les requêtes emprunteront.

Par exemple, "MVC" est un middleware qui doit être définit dans cette méthode.

```csharp
// Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        app.UseMvC();
    }
```
Lorsque la requête atteindra le middleware MVC, elle sera redirigé vers le bon controleur et l'action à exécuter.

### [Routing](https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/routing?view=aspnetcore-2.0)


## Que faire ?
Un application Asp.Net Core est mise à votre disposition. L'application à été cassée ~~vicieusement~~ par mes soins.
Votre mission est de la faire fonctionner à nouveau et ainsi permettre la communication avec une application cliente.

## Bonus
Implémentez la création d'une entité "Book" au travers d'un appel "Post" au controleur "BooksController"
