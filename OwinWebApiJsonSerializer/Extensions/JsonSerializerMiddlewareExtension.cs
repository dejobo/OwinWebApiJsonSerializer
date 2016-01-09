using System.Web.Http;
using Owin;

namespace OwinWebApiJsonSerializer
{
    public static class JsonSerializerMiddlewareExtension
    {
        public static void UseWebApiJsonSerialization(this IAppBuilder app, JsonSerializerMiddlewareOption option)
        {
            app.Use<JsonSerializerMiddleware>(option);
        }

        public static void UseWebApiJsonSerialization(this IAppBuilder app, HttpConfiguration configuration)
        {
            app.Use<JsonSerializerMiddleware>(new JsonSerializerMiddlewareOption
            {
                HttpConfiguration = configuration,
                EnableCamelCase = true
            });
        }
    }
}