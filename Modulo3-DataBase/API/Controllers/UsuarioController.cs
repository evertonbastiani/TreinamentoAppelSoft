using Curso.Domain.DTO;
using Curso.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("Get")]
        [Authorize()]
        public IActionResult Get(long Id)
        {
            var usuarioDto = _usuarioService.Get(Id);
            return Ok(usuarioDto);
        }

        [HttpGet]
        [Route("List")]
        [Authorize()]
        public IActionResult List()
        {
            List<UsuarioDTO> listUsuarios = _usuarioService.List();
            return Ok(listUsuarios);
        }

        [HttpPost]
        [Route("Insert")]
        [Authorize()]
        public IActionResult Insert(UsuarioDTO usuarioDto)
        {
            return Ok(_usuarioService.Insert(usuarioDto));
        }

        [HttpPut]
        [Route("Update")]
        [Authorize()]
        public IActionResult Update(UsuarioDTO usuarioDto)
        {
            return Ok(_usuarioService.Update(usuarioDto));
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize()]
        public IActionResult Delete(long Id)
        {
            return Ok(_usuarioService.Delete(Id));
        }

        [HttpGet]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login(string login,string senha)
        {
            return Ok(_usuarioService.Login(login, senha));
        }
    }
}
