using System;

namespace P5Tech.TwoWheelManager.Domain
{
    public class Locacao
    {
        public Guid Id { get; init; }
        public decimal ValorDiaria { get; private set; }
        public Guid EntregadorId { get; init; }
        public Guid MotoId { get; init; }
        public DateOnly DataInicio { get; init; }
        public DateOnly? DataTermino { get; init; }
        public DateOnly? DataPrevisaoTermino { get; init; }
        public DateOnly? DataDevolucao { get; private set; }
        public int Plano { get; init; }

        public decimal Total
            => LocacaoRule.CalculaDiaria(DataPrevisaoTermino, DataInicio, ValorDiaria)
            + LocacaoRule.CalcularMulta(DataDevolucao, DataPrevisaoTermino, Plano, ValorDiaria);

        public string Identificador => Id.ToString();

        public void SetDevolucao(DateOnly data) => DataDevolucao = data;

        public void SetValorDiaria(decimal valorDiaria) => ValorDiaria = valorDiaria;
    }
}