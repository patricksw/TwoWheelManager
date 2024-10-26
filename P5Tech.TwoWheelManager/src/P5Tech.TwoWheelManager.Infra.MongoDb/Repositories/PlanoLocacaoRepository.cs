using MapsterMapper;
using MongoDB.Driver;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Parameters;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;
using P5Tech.TwoWheelManager.Infra.MongoDb.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Repositories
{
    public class PlanoLocacaoRepository(IMongoContext context, IMapper mapper) : IPlanoLocacaoRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task InitialData()
        {
            var listDto = new List<PlanoLocacaoCollection>
            {
                new() {
                    Id = Guid.NewGuid(),
                    ValorDiaria = 30,
                    Plano = 7
                },
                new() {
                    Id = Guid.NewGuid(),
                    ValorDiaria = 28,
                    Plano = 15
                },
                new() {
                    Id = Guid.NewGuid(),
                    ValorDiaria = 22,
                    Plano = 30
                },
                new() {
                    Id = Guid.NewGuid(),
                    ValorDiaria = 20,
                    Plano = 45
                },
                new() {
                    Id = Guid.NewGuid(),
                    ValorDiaria = 18,
                    Plano = 50
                }
            };

            await _context.CollectionPlanoLocacoes.InsertManyAsync(listDto);
        }

        public async Task<bool> Exists() => await _context.CollectionPlanoLocacoes.CountDocumentsAsync(FilterDefinition<PlanoLocacaoCollection>.Empty) > 0;

        public async Task<PlanoLocacao> GetByParameter(PlanoLocacaoParameter filter)
        {
            var dto = await _context.CollectionPlanoLocacoes.Find(x => x.Plano == filter.Plano).FirstOrDefaultAsync();
            return _mapper.Map<PlanoLocacao>(dto);
        }

        public async Task<PlanoLocacao> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionPlanoLocacoes.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<PlanoLocacao>(dto);
        }

        private static FilterDefinition<PlanoLocacaoCollection> FindById(Guid id) => Builders<PlanoLocacaoCollection>.Filter.Eq(m => m.Id, id);
    }
}