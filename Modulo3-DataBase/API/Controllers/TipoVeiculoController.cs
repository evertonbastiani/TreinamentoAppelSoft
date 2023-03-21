using Curso.Domain.DTO;
using Curso.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoVeiculoController : ControllerBase
    {
        private readonly ITipoVeiculoService _tipoVeiculoService;

        public TipoVeiculoController(ITipoVeiculoService serviceTipoVeiculo)
        {
            _tipoVeiculoService = serviceTipoVeiculo;
        }

        [HttpGet]
        [Route("Get")]
        [Authorize()]
        public IActionResult Get(long Id)
        {
            var tipoVeiculo = _tipoVeiculoService.Get(Id);
            return Ok(tipoVeiculo);
        }

        [HttpGet]
        [Route("List")]
        [Authorize()]
        public IActionResult List()
        {
            List<TipoVeiculoDTO> listVeiculos = _tipoVeiculoService.List();
            return Ok(listVeiculos);
        }

        [HttpPost]
        [Route("Insert")]
        [Authorize()]
        public IActionResult Insert(TipoVeiculoDTO tipoVeiculoDTO)
        {
            return Ok(_tipoVeiculoService.Insert(tipoVeiculoDTO));            
        }

        [HttpPut]
        [Route("Update")]
        [Authorize()]
        public IActionResult Update(TipoVeiculoDTO tipoVeiculoDTO)
        {
            return Ok(_tipoVeiculoService.Update(tipoVeiculoDTO));
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize()]
        public IActionResult Delete(long Id)
        {
            return Ok(_tipoVeiculoService.Delete(Id));
        }
    }
}
