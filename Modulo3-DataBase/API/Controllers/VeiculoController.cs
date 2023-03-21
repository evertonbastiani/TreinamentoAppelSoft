using Curso.Domain.DTO;
using Curso.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService= veiculoService;
        }

        [HttpGet]
        [Route("Get")]
        [Authorize()]
        public IActionResult Get(long Id)
        {
            var veiculo = _veiculoService.Get(Id);
            return Ok(veiculo);
        }

        [HttpGet]
        [Route("List")]
        [Authorize()]
        public IActionResult List()
        {
            List<VeiculoDTO> listVeiculos = _veiculoService.List();
            return Ok(listVeiculos);
        }

        [HttpPost]
        [Route("Insert")]
        [Authorize()]
        public IActionResult Insert(VeiculoDTO veiculoDTO)
        {
            return Ok(_veiculoService.Insert(veiculoDTO));
        }

        [HttpPut]
        [Route("Update")]
        [Authorize()]
        public IActionResult Update(VeiculoDTO veiculoDTO)
        {
            return Ok(_veiculoService.Update(veiculoDTO));
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize()]
        public IActionResult Delete(long Id)
        {
            return Ok(_veiculoService.Delete(Id));
        }


    }
}
