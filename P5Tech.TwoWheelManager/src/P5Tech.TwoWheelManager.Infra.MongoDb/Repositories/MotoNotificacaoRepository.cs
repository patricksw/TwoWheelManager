using MapsterMapper;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Infra.MongoDb.Collections;
using P5Tech.TwoWheelManager.Infra.MongoDb.Context;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Infra.MongoDb.Repositories
{
    public class MotoNotificacaoRepository(IMongoContext context, IMapper mapper) : IMotoNotificacaoRepository
    {
        private readonly IMongoContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Guid> Create(Moto domain)
        {
            var dto = _mapper.Map<MotoNotificacaoCollection>(domain);
            await _context.CollectionMotos.InsertOneAsync(dto);
            return dto.Id;
        }
    }
}