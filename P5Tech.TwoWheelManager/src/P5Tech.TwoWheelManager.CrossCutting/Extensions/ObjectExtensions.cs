using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace P5Tech.TwoWheelManager.CrossCutting.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            if (obj is null) return default;

            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                Formatting = Formatting.None
            });
        }

        public static T JsonToType<T>(this string value)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            catch
            {
                return default;
            }
        }
    }
}