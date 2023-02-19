using Curso.Repository.Repository;
using Curso.Repository.Interfaces;
using Curso.Domain.DTO;
using Curso.Service.Interfaces;
using Curso.Domain.Entities;

namespace Curso.Service.Services
{
    public class ServiceVeiculo : ServiceBase, IServiceVeiculo
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ServiceVeiculo(IVeiculoRepository veiculoRepository)
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

            //Sem o mapper, teríamos que converter VeiculoDTO em Veiculo diretamente
            //var veiculo = _veiculoRepository.Insert(new Veiculo
            //{
            //    Id = veiculoDTO.Id,
            //    Placa = veiculoDTO.Placa,
            //    Marca = veiculoDTO.Marca,
            //    Modelo = veiculoDTO.Modelo,
            //    Cor = veiculoDTO.Cor,
            //    Ano = veiculoDTO.Ano,
            //    Tipo = new TipoVeiculo { Id = veiculoDTO.Tipo.Id, Descricao = veiculoDTO.Tipo.Descricao }
            //});

            veiculoDTO.Id = veiculo.Id;
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
