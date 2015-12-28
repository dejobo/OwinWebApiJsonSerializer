using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task>;


namespace OwinWebApiJsonSerializer
{
    public class JsonSerializerMiddleware
    {
        private readonly AppFunc _next;
        private readonly HttpConfiguration _config;
        private readonly bool _allowCamelCasing;

        public JsonSerializerMiddleware(AppFunc next, JsonSerializerMiddlewareOption option)
        {
            _next = next;
            _config = option.HttpConfiguration;
            _allowCamelCasing = option.EnableCamelCase;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            //Json seririalization and reference loop handling
            var json = _config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            _config.Formatters.Remove(_config.Formatters.XmlFormatter);

            //json setting
            var jsonSerializerSetting = _config.Formatters.JsonFormatter.SerializerSettings;
            
            //set to camel casing
            if (_allowCamelCasing)
            {
                jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
            await _next(env);
        }
    }
}