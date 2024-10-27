using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Repositories
{
    public interface IMotoNotificacaoRepository
    {
        Task<Guid> Create(Moto domain);
    }
}