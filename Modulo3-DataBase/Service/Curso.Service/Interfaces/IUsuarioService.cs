using Curso.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Service.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> List();
        UsuarioDTO Insert(UsuarioDTO usuarioDTO);
        bool Delete(long id);
        UsuarioDTO Update(UsuarioDTO usuarioDTO);
        UsuarioDTO Get(long id);

        UsuarioDTO Login(string login, string senha);
    }
}
