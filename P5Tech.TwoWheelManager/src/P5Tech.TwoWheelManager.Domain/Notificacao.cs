using Newtonsoft.Json;

namespace P5Tech.TwoWheelManager.Domain
{
    public class Notificacao
    {
        public string Value { get; set; }

        public static Notificacao New<T>(T value) => new() { Value = JsonConvert.SerializeObject(value) };

        public T GetValue<T>() => JsonConvert.DeserializeObject<T>(Value);
    }
}