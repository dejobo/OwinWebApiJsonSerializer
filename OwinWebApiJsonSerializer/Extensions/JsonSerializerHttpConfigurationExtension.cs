using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OwinWebApiJsonSerializer
{
    public static class JsonSerializerHttpConfigurationExtension
    {
        public static void UseWebApiJsonSerialization(this HttpConfiguration config, bool useCamelCase = true)
        {
            //Json seririalization and reference loop handling
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            //json setting
            var jsonSerializerSetting = config.Formatters.JsonFormatter.SerializerSettings;

            //set to camel casing
            if (useCamelCase)
            {
                jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }
        }
    }
}
