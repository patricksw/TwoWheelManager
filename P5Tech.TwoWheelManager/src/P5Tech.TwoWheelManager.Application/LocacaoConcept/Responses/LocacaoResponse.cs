using System;
using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.LocacaoConcept.Responses
{
    public record LocacaoResponse(string Identificador,
                                  [property: JsonPropertyName("valor_diaria")] decimal ValorDiaria,
                                  [property: JsonPropertyName("entregador_id")] Guid EntregadorId,
                                  [property: JsonPropertyName("moto_id")] Guid MotoId,
                                  [property: JsonPropertyName("data_inicio")] DateOnly DataInicio,
                                  [property: JsonPropertyName("data_termino")] DateOnly? DataTermino,
                                  [property: JsonPropertyName("data_previsao_termino")] DateOnly? DataPrevisaoTermino,
                                  [property: JsonPropertyName("data_devolucao")] DateOnly? DataDevolucao,
                                  decimal Total);
}