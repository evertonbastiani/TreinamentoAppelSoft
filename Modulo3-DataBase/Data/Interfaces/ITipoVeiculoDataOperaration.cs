using Curso.Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Data.Interfaces
{
    public interface ITipoVeiculoDataOperaration
    {
        List<TipoVeiculoDB> List();
        TipoVeiculoDB Insert(TipoVeiculoDB tipoVeiculoDB);
        bool Delete(long id);
        TipoVeiculoDB Update(TipoVeiculoDB tipoVeiculoDB);
        TipoVeiculoDB Get(long id);
    }
}
