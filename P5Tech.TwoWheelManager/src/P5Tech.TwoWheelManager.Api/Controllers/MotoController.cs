using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using P5Tech.TwoWheelManager.Application.Requests;
using P5Tech.TwoWheelManager.Application.Responses;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Api.Controllers
{
    [ApiController]
    [Route("motos")]
    public class MotoController(IMotoService motoService, IMapper mapper) : Controller
    {
        private readonly IMotoService _motoService = motoService;
        private readonly IMapper _mapper = mapper;

        [HttpGet("")]
        public async Task<IEnumerable<MotoResponse>> GetAll()
        {
            var motos = await _motoService.GetAll();
            return _mapper.Map<IEnumerable<MotoResponse>>(motos);
        }

        [HttpGet("{id}")]
        public async Task<MotoResponse> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
            var moto = await _motoService.GetById(_id);
            return _mapper.Map<MotoResponse>(moto);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(AddMotoRequest request)
        {
            try
            {
                return Ok(await _motoService.Add(_mapper.Map<Moto>(request)));
            }
            catch
            {
                return BadRequest(BaseResponse.Invalid());
            }
        }

        [HttpPut("{id}/placa")]
        public async Task<IActionResult> Update(string id, EditPlacaRequest request)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                await _motoService.UpdatePlaca(_id, request.Placa);
                return Ok(BaseResponse.Sucesss("Placa modificada com sucesso"));
            }
            catch
            {
                return BadRequest(BaseResponse.Invalid());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                await _motoService.Delete(_id);
                return Ok();
            }
            catch
            {
                return BadRequest(BaseResponse.Invalid());
            }
        }
    }
}