using System;
using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.LocacaoConcept.Requests
{
    public record AddLocacaoRequest([property: JsonPropertyName("entregador_id")] Guid EntregadorId,
                                    [property: JsonPropertyName("moto_id")] Guid MotoId,
                                    [property: JsonPropertyName("data_inicio")] DateOnly DataInicio,
                                    [property: JsonPropertyName("data_termino")] DateOnly? DataTermino,
                                    [property: JsonPropertyName("data_previsao_termino")] DateOnly? DataPrevisaoTermino,
                                    int Plano)
    {
        public Guid Id { get => Guid.NewGuid(); }
    }
}