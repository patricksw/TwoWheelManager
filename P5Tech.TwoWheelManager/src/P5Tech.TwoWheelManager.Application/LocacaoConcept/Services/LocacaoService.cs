using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Parameters;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Services
{
    public class LocacaoService(ILocacaoRepository repository, IPlanoLocacaoRepository planoLocacaoRepository) : ILocacaoService
    {
        private readonly ILocacaoRepository _repository = repository;
        private readonly IPlanoLocacaoRepository _planoLocacaoRepository = planoLocacaoRepository;

        public async Task<Locacao> GetById(Guid id) => await _repository.Read(id);

        public async Task<Guid> Add(Locacao locacao)
        {
            var diaria = await _planoLocacaoRepository.GetByParameter(new PlanoLocacaoParameter(locacao.Plano)) ?? throw new InvalidDataException();
            locacao.SetValorDiaria(diaria.ValorDiaria);
            return await _repository.Create(locacao);
        }

        public async Task SetDevolucao(Guid id, DateOnly devolucao)
        {
            var locacao = await _repository.Read(id);
            locacao.SetDevolucao(devolucao);
            await _repository.Update(id, locacao);
        }
    }
}