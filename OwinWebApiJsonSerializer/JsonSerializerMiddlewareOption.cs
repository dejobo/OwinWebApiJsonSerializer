using System.Web.Http;

namespace OwinWebApiJsonSerializer
{
    public class JsonSerializerMiddlewareOption
    {
        public HttpConfiguration HttpConfiguration { get; set; }
        public bool EnableCamelCase { get; set; }   
    }
}