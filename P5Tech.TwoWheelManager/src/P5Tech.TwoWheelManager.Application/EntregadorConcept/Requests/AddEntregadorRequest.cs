using System;
using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.EntregadorConcept.Requests
{
    public record AddEntregadorRequest(string Identificador,
                                       string Nome,
                                       string Cnpj,
                                       [property: JsonPropertyName("data_nascimento")] DateTime DataNascimento,
                                       [property: JsonPropertyName("numero_cnh")] string NumeroCnh,
                                       [property: JsonPropertyName("tipo_cnh")] string TipoCnh,
                                       [property: JsonPropertyName("imagem_cnh")] string ImagemCnh)
    {
        public Guid Id { get => Guid.NewGuid(); }
    }
}