using Owin;

namespace OwinWebApiJsonSerializer
{
    public static class JsonSerializerMiddlewareExtension
    {
        public static void UseWebApiJsonSerialization(this IAppBuilder app, JsonSerializerMiddlewareOption option)
        {
            app.Use<JsonSerializerMiddleware>(option);
        }
    }
}