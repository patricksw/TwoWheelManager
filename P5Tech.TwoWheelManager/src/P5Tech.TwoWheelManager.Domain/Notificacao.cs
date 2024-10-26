namespace P5Tech.TwoWheelManager.Domain
{
    public class Notificacao
    {
        public object Value { get; set; }

        public static Notificacao New(object value) => new() { Value = value };
    }
}