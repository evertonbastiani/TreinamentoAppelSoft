using Curso.Domain.DTO;

namespace Curso.Service.Interfaces
{
    public interface IVeiculoService
    {
        List<VeiculoDTO> List();
        VeiculoDTO Insert(VeiculoDTO veiculoDB);
        bool Delete(long id);
        VeiculoDTO Update(VeiculoDTO veiculoDB);
        VeiculoDTO Get(long id);
    }
}
