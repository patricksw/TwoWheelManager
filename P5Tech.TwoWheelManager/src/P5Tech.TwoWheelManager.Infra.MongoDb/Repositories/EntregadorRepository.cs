using MapsterMapper;
using MongoDB.Driver;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;
using P5Tech.TwoWheelManager.Infra.MongoDb.Context;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Repositories
{
    public class EntregadorRepository(IMongoContext context, IMapper mapper) : IEntregadorRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Entregador domain)
        {
            var dto = _mapper.Map<EntregadorCollection>(domain);
            await _context.CollectionEntregadores.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Entregador> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionEntregadores.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Entregador>(dto);
        }

        public async Task<bool> Update(Guid id, Entregador domain)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionEntregadores.Find(filter).FirstOrDefaultAsync();

            dto.Identificador = domain.Identificador;
            dto.Nome = domain.Nome;
            dto.Cnpj = domain.Cnpj;
            dto.DataNascimento = domain.DataNascimento;
            dto.NumeroCnh = domain.NumeroCnh;
            dto.TipoCnh = domain.TipoCnh;

            ReplaceOneResult updateResult = await _context.CollectionEntregadores.ReplaceOneAsync(filter: g => g.Id == dto.Id, replacement: dto);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        private static FilterDefinition<EntregadorCollection> FindById(Guid id) => Builders<EntregadorCollection>.Filter.Eq(m => m.Id, id);
    }
}