using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Services
{
    public interface IEntregadorService
    {
        Task<Guid> Add(Entregador entregador);
        Task UpdateImagemCnh(Guid id, string imagemCnh);
        //Task Update(Guid id, string placa);
    }
}