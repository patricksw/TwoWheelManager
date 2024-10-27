using P5Tech.TwoWheelManager.Domain;
using System;
using Xunit;

namespace P5Tech.TwoWheelManager.UnitTest
{
    public class LocacaoRuleTests
    {
        [Fact]
        public void CalculaDiaria_DataDevolucaoNull_ReturnsZero()
        {
            // Arrange
            DateOnly? dataDevolucao = null;
            DateOnly dataInicio = DateOnly.FromDateTime(DateTime.Now);
            decimal valorDiaria = 100;

            // Act
            var result = LocacaoRule.CalculaDiaria(dataDevolucao, dataInicio, valorDiaria);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculaDiaria_ValidDates_ReturnsCorrectValue()
        {
            // Arrange
            DateOnly dataInicio = DateOnly.FromDateTime(DateTime.Now);
            DateOnly dataDevolucao = dataInicio.AddDays(7);
            decimal valorDiaria = 30;

            // Act
            var result = LocacaoRule.CalculaDiaria(dataDevolucao, dataInicio, valorDiaria);

            // Assert
            Assert.Equal(210, result);
        }

        [Fact]
        public void CalcularMulta_DataDevolucaoNull_ReturnsZero()
        {
            // Arrange
            DateOnly? dataDevolucao = null;
            DateOnly? dataPrevisaoTermino = DateOnly.FromDateTime(DateTime.Now);
            int plano = 7;
            decimal valorDiaria = 30;

            // Act
            var result = LocacaoRule.CalcularMulta(dataDevolucao, dataPrevisaoTermino, plano, valorDiaria);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalcularMulta_DataPrevisaoTerminoNull_ReturnsZero()
        {
            // Arrange
            DateOnly? dataDevolucao = DateOnly.FromDateTime(DateTime.Now);
            DateOnly? dataPrevisaoTermino = null;
            int plano = 7;
            decimal valorDiaria = 30;

            // Act
            var result = LocacaoRule.CalcularMulta(dataDevolucao, dataPrevisaoTermino, plano, valorDiaria);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalcularMulta_DevolucaoAntesPrevisao_ReturnsCorrectValue()
        {
            // Arrange
            DateOnly dataDevolucao = DateOnly.FromDateTime(DateTime.Now);
            DateOnly dataPrevisaoTermino = dataDevolucao.AddDays(2);
            int plano = 7;
            decimal valorDiaria = 30;

            // Act
            var result = LocacaoRule.CalcularMulta(dataDevolucao, dataPrevisaoTermino, plano, valorDiaria);

            // Assert
            Assert.Equal(12, result); // 30 * 2 * 0.2
        }

        [Fact]
        public void CalcularTotal_DevolucaoAntesPrevisao_ReturnsCorrectValue()
        {
            // Arrange
            var locacao = new Locacao
            {
                DataInicio = DateOnly.FromDateTime(DateTime.Now),
                DataPrevisaoTermino = DateOnly.FromDateTime(DateTime.Now).AddDays(7),
                Plano = 7,
            };
            locacao.SetDevolucao(DateOnly.FromDateTime(DateTime.Now).AddDays(5));
            locacao.SetValorDiaria(30);

            // Act
            var result = locacao.Total;

            // Assert
            Assert.Equal(222, result); // 30 * 7 + 30 * 2 * 0.2
        }


        [Fact]
        public void CalcularMulta_DevolucaoDepoisPrevisao_ReturnsCorrectValue()
        {
            // Arrange
            DateOnly dataPrevisaoTermino = DateOnly.FromDateTime(DateTime.Now);
            DateOnly dataDevolucao = dataPrevisaoTermino.AddDays(2);
            int plano = 7;
            decimal valorDiaria = 100;

            // Act
            var result = LocacaoRule.CalcularMulta(dataDevolucao, dataPrevisaoTermino, plano, valorDiaria);

            // Assert
            Assert.Equal(100, result); // 2 * 50
        }
    }
}
