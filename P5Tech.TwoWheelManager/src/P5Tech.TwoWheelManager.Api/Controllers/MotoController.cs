using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P5Tech.TwoWheelManager.Application.Interfaces;
using P5Tech.TwoWheelManager.Application.Requests;
using System.Threading.Tasks;

namespace P5Tech.TwoWheelManager.Api.Controllers
{
    [ApiController]
    [Route("motos")]
    public class MotoController(IMotoService motoService) : Controller
    {
        private readonly IMotoService _motoService = motoService;

        [HttpGet("te1")]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(MotoRequest request)
        {
            try
            {
                return Ok(await _motoService.Save(request));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("te2")]
        public ActionResult Edit(int id)
        {
            return View();
        }


    }
}
