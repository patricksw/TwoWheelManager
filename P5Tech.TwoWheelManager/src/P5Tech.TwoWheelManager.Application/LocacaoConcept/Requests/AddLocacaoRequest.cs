using System;
using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.LocacaoConcept.Requests
{
    public record AddLocacaoRequest([property: JsonPropertyName("entregador_id")] Guid EntregadorId,
                                    [property: JsonPropertyName("moto_id")] Guid MotoId,
                                    [property: JsonPropertyName("data_inicio")] DateTime DataInicio,
                                    [property: JsonPropertyName("data_termino")] DateTime? DataTermino,
                                    [property: JsonPropertyName("data_previsao_termino")] DateTime? DataPrevisaoTermino,
                                    int Plano)
    {
        public Guid Id { get => Guid.NewGuid(); }
    }
}