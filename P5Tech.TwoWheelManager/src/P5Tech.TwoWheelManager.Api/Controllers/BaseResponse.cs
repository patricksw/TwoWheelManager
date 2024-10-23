namespace P5Tech.TwoWheelManager.Api.Controllers
{
    public class BaseResponse
    {
        public string Mensagem { get; set; }

        public static BaseResponse Invalid() => new() { Mensagem = "Dados inválidos" };
        public static BaseResponse Sucesss(string message) => new() { Mensagem = message };
    }
}