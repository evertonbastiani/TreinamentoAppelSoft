using Curso.Domain.Entities;

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
