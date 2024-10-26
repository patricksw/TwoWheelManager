using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Queue;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Services
{
    public class MotoService(IMotoRepository repository, INotificacaoKafkaProducer notificacaoKafkaProducer) : IMotoService
    {
        private readonly IMotoRepository _repository = repository;
        private readonly INotificacaoKafkaProducer _notificacaoKafkaProducer = notificacaoKafkaProducer;

        public async Task<IEnumerable<Moto>> GetAll()
        {
            return await _repository.ReadAll();
        }
        public async Task<Moto> GetById(Guid id) => await _repository.Read(id);

        public async Task<Guid> Add(Moto moto)
        {
            if ((await _repository.ReadAll()).Any(x => x.Placa == moto.Placa))
                throw new InvalidOperationException();

            _notificacaoKafkaProducer.Produce(Notificacao.New(moto));

            return await _repository.Create(moto);
        }

        public async Task UpdatePlaca(Guid id, string placa)
        {
            var moto = await _repository.Read(id);
            moto.SetPlaca(placa);
            await _repository.Update(id, moto);
        }
        public async Task<bool> Delete(Guid id) => await _repository.Delete(id);
    }
}