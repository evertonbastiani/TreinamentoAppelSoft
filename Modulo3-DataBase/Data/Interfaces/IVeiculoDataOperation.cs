using Curso.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Interfaces
{
    public interface IVeiculoDataOperation
    {
        List<VeiculoDB> List();
        VeiculoDB Insert(VeiculoDB veiculoDB);
        bool Delete(long id);
        VeiculoDB Update(VeiculoDB veiculoDB);
    }
}
