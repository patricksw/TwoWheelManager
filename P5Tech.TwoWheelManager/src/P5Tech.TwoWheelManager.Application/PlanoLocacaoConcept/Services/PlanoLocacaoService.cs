using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Parameters;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Services
{
    public class PlanoLocacaoService(IPlanoLocacaoRepository repository) : IPlanoLocacaoService
    {
        private readonly IPlanoLocacaoRepository _repository = repository;

        public async Task InitialData()
        {
            if (await _repository.Exists())
                return;
            await _repository.InitialData();
        }

        public async Task<PlanoLocacao> GetByPlano(int plano)
        {
            var filter = new PlanoLocacaoParameter(plano);
            return await _repository.GetByParameter(filter);
        }
    }
}