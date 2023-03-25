using AppelSoft.Mutitenancy.API.Context;
using AppelSoft.Mutitenancy.API.Repository.Entities;
using AppelSoft.Mutitenancy.API.Repository.Interface;

namespace AppelSoft.Mutitenancy.API.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly MultitenancyContext _context;       

        public UserRepository(MultitenancyContext context)
        {
          
            _context = context;
        }

        public List<User> List()
        {
            return _context.Usuario.OrderBy(x => x.Id).ToList();
        }

        public User Insert(User usuario)
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

        public User Update(User usuario)
        {
            _context.ChangeTracker.Clear();
            _context.Usuario.Update(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public User Get(long id)
        {
            return _context.Usuario.Where(x => x.Id == id).FirstOrDefault();           
        }

        public User Login(string login, string senha)
        {            
            return _context.Usuario.Where(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }
    }
}
