using System;

namespace P5Tech.TwoWheelManager.Application.Responses
{
    public class MotoResponse
    {
        public Guid Id { get; set; }
        public string Identificador { get; set; }
        public int Ano { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
    }
}