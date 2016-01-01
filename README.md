# OwinWebApiJsonSerializer

This OWIN Middleware serializes and formats JSON results from ASP.NET Web API Hosted within OWIN server/Self Hosted Owin Web API.


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
    
    app.UseWebApiJsonSerialization(new JsonSerializerMiddlewareOption
    {
        HttpConfiguration = config,
        EnableCamelCase = false
    });
}

```
