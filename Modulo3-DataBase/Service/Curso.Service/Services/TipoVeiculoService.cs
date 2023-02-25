﻿using Curso.Domain.DTO;
using Curso.Domain.Entities;
using Curso.Repository.Interfaces;
using Curso.Service.Interfaces;

namespace Curso.Service.Services
{
    public class TipoVeiculoService:ServiceBase, ITipoVeiculoService
    {
        private readonly ITipoVeiculoRepository _tipoVeiculoRepository;

        public TipoVeiculoService(ITipoVeiculoRepository tipoVeiculoRepository)
        {
            _tipoVeiculoRepository = tipoVeiculoRepository;
        }

        public bool Delete(long id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("id", "O Id do tipo de produto não foi informado.");
            }

            return _tipoVeiculoRepository.Delete(id);
        }

        public TipoVeiculoDTO Get(long id)
        {
            if(id <= 0)
            {
                throw new ArgumentNullException("id","O Id do tipo de produto não foi informado.");
            }
            var tipoVeiculo = _tipoVeiculoRepository.Get(id);
            return mapper.Map<TipoVeiculoDTO>(tipoVeiculo);           
        }

        public TipoVeiculoDTO Insert(TipoVeiculoDTO tipoVeiculoDTO)
        {
            //Validação da descrição.
            if (String.IsNullOrEmpty(tipoVeiculoDTO.Descricao)){
                throw new ArgumentNullException("Descricao", "O campo descrição é obrigatório.");
            }
            
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
            //Validação da descrição
            if (String.IsNullOrEmpty(tipoVeiculoDTO.Descricao))
            {
                throw new ArgumentNullException("Descricao", "O campo descrição é obrigatório.");
            }

            TipoVeiculo tipoVeiculo = mapper.Map<TipoVeiculo>(tipoVeiculoDTO);
            tipoVeiculo = _tipoVeiculoRepository.Update(tipoVeiculo);

            return mapper.Map<TipoVeiculoDTO>(tipoVeiculo) ;
        }
    }
}
