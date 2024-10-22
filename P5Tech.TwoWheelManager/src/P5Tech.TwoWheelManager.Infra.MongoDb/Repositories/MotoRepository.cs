using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapsterMapper;
using MongoDB.Driver;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Repositories
{
    public class MotoRepository : IMotoRepository
    {
        private readonly IMongoCollection<MotoCollection> _mongoCollection;
        private readonly IMapper _mapper;

        public MotoRepository(IMongoCollection<MotoCollection> mongoCollection, IMapper mapper)
        {
            _mongoCollection = mongoCollection;
            _mapper = mapper;
        }

        public async Task<string> Create(Moto account)
        {
            var dto = _mapper.Map<MotoCollection>(account);
            await _mongoCollection.InsertOneAsync(dto);
            return dto.Id;
        }

        public async Task<Moto> Read(string id)
        {
            var dto = await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Moto>(dto);
        }

        public async Task<IEnumerable<Moto>> ReadAll()
        {
            var dto = await _mongoCollection.Find(x => true).ToListAsync();
            return dto.Select(x => _mapper.Map<Moto>(x));
        }

        public async Task Update(Moto account)
        {
            var dto = _mapper.Map<MotoCollection>(account);
            await _mongoCollection.ReplaceOneAsync(x => x.Id == account.Id, dto);
        }

        public async Task Delete(string id) => await _mongoCollection.DeleteOneAsync(x => x.Id == id);
    }
}