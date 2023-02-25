using Curso.Domain.Entities;

namespace Curso.Repository.Interfaces
{
    public interface ITipoVeiculoRepository
    {
        List<TipoVeiculo> List();
        TipoVeiculo Insert(TipoVeiculo tipoVeiculo);
        bool Delete(long id);
        TipoVeiculo Update(TipoVeiculo tipoVeiculo);
        TipoVeiculo Get(long id);
    }
}
