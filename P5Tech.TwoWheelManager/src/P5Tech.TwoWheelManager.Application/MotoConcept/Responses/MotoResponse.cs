using System;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Responses
{
    public record MotoResponse(Guid Id,
                               string Identificador,
                               int Ano,
                               string Modelo,
                               string Placa);
}