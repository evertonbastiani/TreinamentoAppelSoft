using AppelSoft.Mutitenancy.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppelSoft.Mutitenancy.API.Repository.Interface
{
    public interface IUserRepository
    {
        List<User> List();
        User Insert(User tipoVeiculo);
        bool Delete(long id);
        User Update(User tipoVeiculo);
        User Get(long id);

        User Login(string login, string senha);
    }
}
