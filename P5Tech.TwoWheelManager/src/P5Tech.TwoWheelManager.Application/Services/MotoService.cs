using MapsterMapper;
using P5Tech.TwoWheelManager.Application.Interfaces;
using P5Tech.TwoWheelManager.Application.Requests;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Repositories;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Application.Services
{
    public class MotoService(IMotoRepository motoRepository, IMapper mapper) : IMotoService
    {
        private readonly IMotoRepository _motoRepository = motoRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<string> Save(MotoRequest request)
        {
            var domain = _mapper.Map<Moto>(request);
            return await _motoRepository.Create(domain);
        }
    }
}
