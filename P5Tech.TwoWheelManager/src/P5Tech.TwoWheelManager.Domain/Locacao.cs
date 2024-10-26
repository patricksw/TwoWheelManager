using System;

namespace P5Tech.TwoWheelManager.Domain
{
    public class Locacao
    {
        public Guid Id { get; init; }
        public decimal ValorDiaria { get; private set; }
        public Guid EntregadorId { get; init; }
        public Guid MotoId { get; init; }
        public DateTime DataInicio { get; init; }
        public DateTime? DataTermino { get; init; }
        public DateTime? DataPrevisaoTermino { get; init; }
        public DateTime? DataDevolucao { get; private set; }
        public int Plano { get; init; }

        public string Identificador => Id.ToString();

        public void SetDevolucao(DateTime data) => DataDevolucao = data;

        public void SetValorDiaria(decimal valorDiaria) => ValorDiaria = valorDiaria;
    }
}