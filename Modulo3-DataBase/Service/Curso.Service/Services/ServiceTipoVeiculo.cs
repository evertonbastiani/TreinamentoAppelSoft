using Curso.Repository.Repository;
using Curso.Repository.Interfaces;
using Curso.Domain.DTO;
using Curso.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curso.Domain.Entities;

namespace Curso.Service.Services
{
    public class ServiceTipoVeiculo:ServiceBase, IServiceTipoVeiculo
    {
        private readonly ITipoVeiculoRepository _tipoVeiculoRepository;

        public ServiceTipoVeiculo(ITipoVeiculoRepository tipoVeiculoRepository)
        {
            _tipoVeiculoRepository = tipoVeiculoRepository;
        }

        public bool Delete(long id)
        {
            return _tipoVeiculoRepository.Delete(id);
        }

        public TipoVeiculoDTO Get(long id)
        {
            var tipoVeiculo = _tipoVeiculoRepository.Get(id);
            return mapper.Map<TipoVeiculoDTO>(tipoVeiculo);           
        }

        public TipoVeiculoDTO Insert(TipoVeiculoDTO tipoVeiculoDTO)
        {
            TipoVeiculo tipoVeiculo = mapper.Map<TipoVeiculo>(tipoVeiculoDTO);
            tipoVeiculo = _tipoVeiculoRepository.Insert(tipoVeiculo);
            return mapper.Map<TipoVeiculoDTO>(tipoVeiculo);          
        }

        public List<TipoVeiculoDTO> List()
        {            
            List<TipoVeiculo> listTipoVeiculo = _tipoVeiculoRepository.List();            
            return mapper.Map<List<TipoVeiculoDTO>>(listTipoVeiculo);   
        }

        public TipoVeiculoDTO Update(TipoVeiculoDTO tipoVeiculoDTO)
        {
            TipoVeiculo tipoVeiculo = mapper.Map<TipoVeiculo>(tipoVeiculoDTO);
            tipoVeiculo = _tipoVeiculoRepository.Update(tipoVeiculo);

            return mapper.Map<TipoVeiculoDTO>(tipoVeiculo) ;
        }
    }
}
