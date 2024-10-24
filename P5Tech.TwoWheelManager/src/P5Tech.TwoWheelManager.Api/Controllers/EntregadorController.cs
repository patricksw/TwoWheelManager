using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using P5Tech.TwoWheelManager.Api.Controllers.Bases;
using P5Tech.TwoWheelManager.Application.EntregadorConcept.Requests;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Api.Controllers
{
    [ApiController]
    [Route("entregadores")]
    public class EntregadorController(IEntregadorService service, IMapper mapper) : ControllerBase
    {
        private readonly IEntregadorService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpPost("")]
        public async Task<IActionResult> Create(AddEntregadorRequest request)
        {
            try
            {
                return Ok(await _service.Add(_mapper.Map<Entregador>(request)));
            }
            catch
            {
                return BadRequest(BaseResponse.Invalid());
            }
        }

        [HttpPost("{id}/cnh")]
        public async Task<IActionResult> UpdateImagemCnh(string id, EditImagemCnhRequest request)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                await _service.UpdateImagemCnh(_id, request.ImagemCnh);
                return Ok();
            }
            catch
            {
                return BadRequest(BaseResponse.Invalid());
            }
        }
    }
}