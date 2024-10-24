using System;
using System.Text.Json.Serialization;

namespace P5Tech.TwoWheelManager.Application.LocacaoConcept.Requests;

public record EditDevolucaoRequest([property: JsonPropertyName("data_devolucao")] DateTime DataDevolucao);