using Curso.Business.DTO;
using Curso.Data.DB;

namespace Curso.Business.Interfaces
{
    public interface ITipoVeiculoBusinessOperation
    {
        List<TipoVeiculoDTO> List();
        TipoVeiculoDTO Insert(TipoVeiculoDTO tipoVeiculoDB);
        bool Delete(long id);
        TipoVeiculoDTO Update(TipoVeiculoDTO tipoVeiculoDB);
        TipoVeiculoDTO Get(long id);
    }
}
