using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.EntregadorConcept.Requests
{
    public record EditImagemCnhRequest([property: JsonPropertyName("imagem_cnh")] string ImagemCnh);
}