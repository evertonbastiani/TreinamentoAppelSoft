using Curso.Domain.Entities;
using Curso.Repository.Context;
using Curso.Repository.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace Curso.Repository.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        private readonly CursoDBContext _context;       

        public UsuarioRepository(CursoDBContext context)
        {
          
            _context = context;
        }

        public List<Usuario> List()
        {
            return _context.Usuario.OrderBy(x => x.Id).ToList();
        }

        public Usuario Insert(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public bool Delete(long id)
        {
            var usuario = this.Get(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                var deleted = _context.SaveChanges();
                return deleted > 0;
            }
            else
            {
                return false;
            }
        }

        public Usuario Update(Usuario usuario)
        {
            _context.ChangeTracker.Clear();
            _context.Usuario.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario Get(long id)
        {
            return _context.Usuario.Where(x => x.Id == id).FirstOrDefault();           
        }

        public Usuario Login(string login, string senha)
        {
            return _context.Usuario.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }
    }
}
