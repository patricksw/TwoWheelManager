using System;

namespace P5Tech.TwoWheelManager.Application.Requests
{
    public record AddMotoRequest(string Identificador,
                                 int Ano,
                                 string Modelo,
                                 string Placa)
    {
        public Guid Id { get => Guid.NewGuid(); }
    }
}