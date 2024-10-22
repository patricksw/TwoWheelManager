using P5Tech.TwoWheelManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface IMotoRepository
    {
        Task<string> Create(Moto account);
        Task Delete(string id);
        Task<Moto> Read(string id);
        Task<IEnumerable<Moto>> ReadAll();
        Task Update(Moto account);
    }
}