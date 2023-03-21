using Curso.Domain.Entities;

namespace Curso.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> List();
        Usuario Insert(Usuario tipoVeiculo);
        bool Delete(long id);
        Usuario Update(Usuario tipoVeiculo);
        Usuario Get(long id);

        Usuario Login(string login, string senha);
    }
}
