using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface ILocacaoRepository
    {
        Task<Guid> Create(Locacao domain);
        Task<Locacao> Read(Guid id);
        Task<IEnumerable<Locacao>> ReadAll();
        Task<bool> Update(Guid id, Locacao domain);
    }
}