using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Services
{
    public interface IMotoService
    {
        Task<Guid> Add(Moto moto);
        Task<bool> Delete(Guid id);
        Task<IEnumerable<Moto>> GetAll();
        Task<Moto> GetById(Guid id);
        Task UpdatePlaca(Guid id, string placa);
    }
}