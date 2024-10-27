using P5Tech.TwoWheelManager.Domain.Parameters;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface IPlanoLocacaoRepository
    {
        Task<bool> Exists();
        Task<PlanoLocacao> GetByParameter(PlanoLocacaoParameter filter);
        Task InitialData();
        Task<PlanoLocacao> Read(Guid id);
    }
}