using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Services
{
    public class LocacaoService(ILocacaoRepository repository) : ILocacaoService
    {
        private readonly ILocacaoRepository _repository = repository;

        public async Task<Locacao> GetById(Guid id) => await _repository.Read(id);

        public async Task<Guid> Add(Locacao locacao)
        {
            return await _repository.Create(locacao);
        }

        public async Task SetDevolucao(Guid id, DateTime devolucao)
        {
            var locacao = await _repository.Read(id);
            locacao.SetDevolucao(devolucao);
            await _repository.Update(id, locacao);
        }
    }
}