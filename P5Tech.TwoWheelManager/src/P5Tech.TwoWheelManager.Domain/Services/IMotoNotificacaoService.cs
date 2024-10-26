using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Domain.Services
{
    public interface IMotoNotificacaoService
    {
        Task Consummer(Moto moto);
    }
}