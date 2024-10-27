using System;

namespace P5Tech.TwoWheelManager.Domain
{
    public static class LocacaoRule
    {
        public static decimal CalculaDiaria(DateOnly? dataDevolucao, DateOnly dataInicio, decimal valorDiaria)
        {
            if (dataDevolucao is null)
                return 0;
            var days = Math.Abs(dataDevolucao.Value.DayNumber - dataInicio.DayNumber);

            return FatorDiaria(days, valorDiaria);
        }

        public static decimal FatorDiaria(int days, decimal valorDiaria) => days * valorDiaria;

        public static decimal CalcularMulta(DateOnly? dataDevolucao,
                                            DateOnly? dataPrevisaoTermino,
                                            int plano,
                                            decimal valorDiaria)
        {
            if (dataDevolucao is null)
                return 0;
            if (dataPrevisaoTermino is null)
                return 0;

            if (dataDevolucao.Value < dataPrevisaoTermino.Value)
            {
                var dias = Math.Abs(dataPrevisaoTermino.Value.DayNumber - dataDevolucao.Value.DayNumber);
                if (plano is 7)
                    return FatorDiaria(dias, valorDiaria) * 0.2m;
                if (plano is 15)
                    return FatorDiaria(dias, valorDiaria) * 0.4m;
                return 0;
            }
            else if (dataDevolucao.Value > dataPrevisaoTermino.Value)
            {
                var diasAtraso = (dataDevolucao.Value.DayNumber - dataPrevisaoTermino.Value.DayNumber);
                return FatorDiaria(diasAtraso, 50);
            }
            return 0;
        }
    }
}