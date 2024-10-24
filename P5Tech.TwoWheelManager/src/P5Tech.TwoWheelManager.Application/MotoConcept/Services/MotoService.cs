using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.MotoConcept.Services
{
    public class MotoService(IMotoRepository repository) : IMotoService
    {
        private readonly IMotoRepository _repository = repository;

        public async Task<IEnumerable<Moto>> GetAll()
        {
            return await _repository.ReadAll();
        }
        public async Task<Moto> GetById(Guid id) => await _repository.Read(id);

        public async Task<Guid> Add(Moto moto)
        {
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