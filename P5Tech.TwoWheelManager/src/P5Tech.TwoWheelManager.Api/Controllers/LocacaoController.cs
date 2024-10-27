using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P5Tech.TwoWheelManager.Api.Controllers.Bases;
using P5Tech.TwoWheelManager.Application.LocacaoConcept.Requests;
using P5Tech.TwoWheelManager.Application.LocacaoConcept.Responses;
using P5Tech.TwoWheelManager.Domain;
using P5Tech.TwoWheelManager.Domain.Services;
using System;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Api.Controllers
{
    [ApiController]
    [Route("locacao")]
    public class LocacaoController(ILocacaoService service, IMapper mapper, ILogger<LocacaoController> logger) : ControllerBase
    {
        private readonly ILogger<LocacaoController> _logger = logger;
        private readonly ILocacaoService _service = service;
        private readonly IMapper _mapper = mapper;

        [HttpPost("")]
        public async Task<IActionResult> Create(AddLocacaoRequest request)
        {
            try
            {
                return Ok(await _service.Add(_mapper.Map<Locacao>(request)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar locacao");
                return BadRequest(BaseResponse.Invalid());
            }
        }

        [HttpGet("{id}")]
        public async Task<LocacaoResponse> GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
            var moto = await _service.GetById(_id);
            return _mapper.Map<LocacaoResponse>(moto);
        }


        [HttpPut("{id}/devolucao")]
        public async Task<IActionResult> UpdateDevolucao(string id, EditDevolucaoRequest request)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid _id)) throw new InvalidCastException();
                await _service.SetDevolucao(_id, request.DataDevolucao);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar devolucao");
                return BadRequest(BaseResponse.Invalid());
            }
        }
    }
}