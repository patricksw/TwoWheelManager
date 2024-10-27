using System;

namespace P5Tech.TwoWheelManager.Domain
{
    public class Moto
    {
        public Guid Id { get; init; }
        public string Identificador { get; init; }
        public int Ano { get; init; }
        public string Modelo { get; init; }
        public string Placa { get; set; }

        public void SetPlaca(string placa) => Placa = placa;
    }
}