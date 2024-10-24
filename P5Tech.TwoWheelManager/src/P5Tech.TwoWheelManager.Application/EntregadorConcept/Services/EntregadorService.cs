using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.EntregadorConcept.Services
{
    public class EntregadorService(IEntregadorRepository repository) : IEntregadorService
    {
        private readonly IEntregadorRepository _repository = repository;

        public async Task<Guid> Add(Entregador entregador)
        {
            return await _repository.Create(entregador);
        }

        public async Task UpdateImagemCnh(Guid id, string imagemCnh)
        {
            var entregador = await _repository.Read(id);
            entregador.SetImagemCnh(imagemCnh);
            await _repository.Update(id, entregador);
        }
    }
}