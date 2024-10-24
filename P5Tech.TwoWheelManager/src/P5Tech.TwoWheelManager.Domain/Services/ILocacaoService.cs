using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Services
{
    public interface ILocacaoService
    {
        Task<Guid> Add(Locacao locacao);
        Task<Locacao> GetById(Guid id);
        Task SetDevolucao(Guid id, DateTime devolucao);
    }
}