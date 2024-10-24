using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface IMotoRepository
    {
        Task<Guid> Create(Moto domain);
        Task<bool> Delete(Guid id);
        Task<Moto> Read(Guid id);
        Task<IEnumerable<Moto>> ReadAll();
        Task<bool> Update(Guid id, Moto domain);
    }
}