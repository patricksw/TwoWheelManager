using System;
using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.LocacaoConcept.Responses
{
    public record LocacaoResponse(string Identificador,
                                  [property: JsonPropertyName("valor_diaria")] decimal ValorDiaria,
                                  [property: JsonPropertyName("entregador_id")] Guid EntregadorId,
                                  [property: JsonPropertyName("moto_id")] Guid MotoId,
                                  [property: JsonPropertyName("data_inicio")] DateTime DataInicio,
                                  [property: JsonPropertyName("data_termino")] DateTime? DataTermino,
                                  [property: JsonPropertyName("data_previsao_termino")] DateTime? DataPrevisaoTermino,
                                  [property: JsonPropertyName("data_devolucao")] DateTime? DataDevolucao);
}