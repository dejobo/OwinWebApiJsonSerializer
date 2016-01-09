# OwinWebApiJsonSerializer

This OWIN Middleware serializes and formats JSON results from ASP.NET Web API Hosted within OWIN server/Self Hosted Owin Web API. 

*There is also support for an ASP.NET Web API Applications without OWIN. See Using within ASP.NET Web API section (v1.0.2+)


## Get it on NuGet!

A compiled library is available via NuGet.

To install via the nuget package console.

    PM>  Install-Package OwinWebApiJsonSerializer 



General Usage
-------------

The example web project shows how you could configure in the startup.cs file.

```CSHARP

public void Configuration(IAppBuilder app)
{
    HttpConfiguration config = new HttpConfiguration();

    -----------------------------
    
    app.UseWebApi(config);
    
    app.UseWebApiJsonSerialization(config);
}

```

More Control...



```CSHARP
public void Configuration(IAppBuilder app)
{
    HttpConfiguration config = new HttpConfiguration();

    -----------------------------
    
    app.UseWebApi(config);
    
    app.UseWebApiJsonSerialization(new JsonSerializerMiddlewareOption
    {
        HttpConfiguration = config,
        EnableCamelCase = false
    });
}

```

Using within ASP.NET Web API WebApiConfig.cs (v1.0.2+)
-------------

Global.asax
```CSHARP

public class WebApiApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        
        -----------------------------------------------
        
        GlobalConfiguration.Configure(WebApiConfig.Register);
    }
   
}
```

WebApiConfig.cs 

```CSHARP
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Web API routes
        config.MapHttpAttributeRoutes();

        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
        
        -------------------------------------------

        config.UseWebApiJsonSerializer();
        
    }
}

```

To disable camel case
```CSHARP
   config.UseWebApiJsonSerializer(false);
```

License
-------

MIT License: http://www.opensource.org/licenses/mit-license.php
