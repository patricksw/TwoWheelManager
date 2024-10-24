using MapsterMapper;
using MongoDB.Driver;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;
using P5Tech.TwoWheelManager.Infra.MongoDb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Repositories
{
    public class PlanoLocacaoRepository(IMongoContext context, IMapper mapper) : IPlanoLocacaoRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Locacao domain)
        {
            var dto = _mapper.Map<LocacaoCollection>(domain);
            await _context.CollectionLocacoes.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Locacao> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionLocacoes.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Locacao>(dto);
        }

        public async Task<IEnumerable<Locacao>> ReadAll()
        {
            var dto = await _context.CollectionLocacoes.Find(x => true).ToListAsync();
            return dto.Select(x => _mapper.Map<Locacao>(x));
        }

        public async Task<bool> Update(Guid id, Locacao domain)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionLocacoes.Find(filter).FirstOrDefaultAsync();

            dto.DataInicio = domain.DataInicio;
            dto.DataTermino = domain.DataTermino;
            dto.DataPrevisaoTermino = domain.DataPrevisaoTermino;
            dto.DataDevolucao = domain.DataDevolucao;
            dto.Plano = domain.Plano;

            ReplaceOneResult updateResult = await _context.CollectionLocacoes.ReplaceOneAsync(filter: g => g.Id == dto.Id, replacement: dto);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        private static FilterDefinition<LocacaoCollection> FindById(Guid id) => Builders<LocacaoCollection>.Filter.Eq(m => m.Id, id);
    }
}