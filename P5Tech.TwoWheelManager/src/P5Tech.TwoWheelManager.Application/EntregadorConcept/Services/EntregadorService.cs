using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.EntregadorConcept.Services
{
    public class EntregadorService(IEntregadorRepository repository, IDocumentRepository documentRepository) : IEntregadorService
    {
        private readonly IEntregadorRepository _repository = repository;
        private readonly IDocumentRepository _documentRepository = documentRepository;

        public async Task<Guid> Add(Entregador entregador)
        {
            var result = await _repository.Create(entregador);

            var doc = new Document { Id = result.ToString() };
            doc.SetContent(Convert.FromBase64String(entregador.ImagemCnh));

            await _documentRepository.SaveDocument(doc, true);
            return result;
        }

        public async Task UpdateImagemCnh(Guid id, string imagemCnh)
        {
            var entregador = await _repository.Read(id);
            entregador.SetImagemCnh(imagemCnh);

            var doc = new Document { Id = id.ToString() };
            doc.SetContent(Convert.FromBase64String(entregador.ImagemCnh));

            await _documentRepository.SaveDocument(doc, true);
        }
    }
}