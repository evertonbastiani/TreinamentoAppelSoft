using Curso.Domain.DTO;
using Curso.Repository.Repository;

namespace Curso.Service.Interfaces
{
    public interface IServiceTipoVeiculo
    {
        List<TipoVeiculoDTO> List();
        TipoVeiculoDTO Insert(TipoVeiculoDTO tipoVeiculoDB);
        bool Delete(long id);
        TipoVeiculoDTO Update(TipoVeiculoDTO tipoVeiculoDB);
        TipoVeiculoDTO Get(long id);
    }
}
