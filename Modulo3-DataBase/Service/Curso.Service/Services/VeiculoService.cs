using Curso.Domain.DTO;
using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using Curso.Service.Interfaces;

namespace Curso.Service.Services
{
    public class VeiculoService : ServiceBase, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }
        public bool Delete(long id)
        {
            return _veiculoRepository.Delete(id);
        }

        public VeiculoDTO Get(long id)
        {
            var veiculo = _veiculoRepository.Get(id);
            return mapper.Map<VeiculoDTO>(veiculo);            
        }

        public VeiculoDTO Insert(VeiculoDTO veiculoDTO)
        {
            var veiculo = _veiculoRepository.Insert(mapper.Map<Veiculo>(veiculoDTO));           
            return veiculoDTO;
        }

        public List<VeiculoDTO> List()
        {
            List<VeiculoDTO> listDto = new List<VeiculoDTO>();
            try
            {
                var listVeiculos = _veiculoRepository.List();
                listDto = mapper.Map<List<VeiculoDTO>>(listVeiculos);
            }
            catch (Exception)
            {

                throw;
            }

            return listDto;
        }

        public VeiculoDTO Update(VeiculoDTO veiculoDTO)
        {
            var veiculoUpdated = _veiculoRepository.Update(mapper.Map<Veiculo>(veiculoDTO));
            return mapper.Map<VeiculoDTO>(veiculoUpdated);        
          
        }
    }
}
