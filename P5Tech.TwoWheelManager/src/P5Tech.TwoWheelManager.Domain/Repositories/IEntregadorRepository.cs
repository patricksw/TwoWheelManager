using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface IEntregadorRepository
    {
        Task<Guid> Create(Entregador domain);
        Task<Entregador> Read(Guid id);
        Task<bool> Update(Guid id, Entregador domain);
    }
}