using System;

namespace P5Tech.TwoWheelManager.Domain
{
    public class Entregador
    {
        public Guid Id { get; init; }
        public string Identificador { get; init; }
        public string Nome { get; init; }
        public string Cnpj { get; init; }
        public DateTime DataNascimento { get; init; }
        public string NumeroCnh { get; init; }
        public string TipoCnh { get; init; }
        public string ImagemCnh { get; private set; }

        public void SetImagemCnh(string imagemCnh) => ImagemCnh = imagemCnh;
    }
}