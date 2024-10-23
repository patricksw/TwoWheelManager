using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.Services
{
    public class MotoService(IMotoRepository motoRepository) : IMotoService
    {
        private readonly IMotoRepository _motoRepository = motoRepository;

        public async Task<IEnumerable<Moto>> GetAll()
        {
            return await _motoRepository.ReadAll();
        }
        public async Task<Moto> GetById(Guid id) => await _motoRepository.Read(id);

        public async Task<Guid> Add(Moto moto)
        {
            return await _motoRepository.Create(moto);
        }

        public async Task UpdatePlaca(Guid id, string placa)
        {
            await _motoRepository.UpdatePlaca(id, placa);
        }

        public async Task<bool> Delete(Guid id) => await _motoRepository.Delete(id);
    }
}