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
    public class MotoRepository(IMongoContext context, IMapper mapper) : IMotoRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Moto domain)
        {
            var dto = _mapper.Map<MotoCollection>(domain);
            await _context.CollectionMotos.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Moto> Read(Guid id)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionMotos.Find(filter).FirstOrDefaultAsync();
            return _mapper.Map<Moto>(dto);
        }

        public async Task<IEnumerable<Moto>> ReadAll()
        {
            var dto = await _context.CollectionMotos.Find(x => true).ToListAsync();
            return dto.Select(x => _mapper.Map<Moto>(x));
        }

        public async Task<bool> Update(Guid id, Moto domain)
        {
            var filter = FindById(id);
            var dto = await _context.CollectionMotos.Find(filter).FirstOrDefaultAsync();

            dto.Identificador = domain.Identificador;
            dto.Ano = domain.Ano;
            dto.Modelo = domain.Modelo;
            dto.Placa = domain.Placa;

            ReplaceOneResult updateResult = await _context.CollectionMotos.ReplaceOneAsync(filter: g => g.Id == dto.Id, replacement: dto);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var filter = FindById(id);
            DeleteResult deleteResult = await _context.CollectionMotos.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        private static FilterDefinition<MotoCollection> FindById(Guid id) => Builders<MotoCollection>.Filter.Eq(m => m.Id, id);
    }
}