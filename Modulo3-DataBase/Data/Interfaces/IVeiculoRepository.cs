using Curso.Domain.Entities;
using Curso.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Repository.Interfaces
{
    public interface IVeiculoRepository
    {
        List<Veiculo> List();
        Veiculo Insert(Veiculo veiculoDB);
        bool Delete(long id);
        Veiculo Update(Veiculo veiculoDB);
        Veiculo Get(long id);
    }
}
