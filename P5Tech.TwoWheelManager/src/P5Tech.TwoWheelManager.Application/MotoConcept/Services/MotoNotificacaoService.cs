using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Services
{
    public class MotoNotificacaoService(IMotoNotificacaoRepository repository) : IMotoNotificacaoService
    {
        private readonly IMotoNotificacaoRepository _repository = repository;

        public async Task Consummer(Moto moto)
        {
            if (moto.Ano is 2024)
                await _repository.Create(moto);
        }
    }
}