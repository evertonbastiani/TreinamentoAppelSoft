using Curso.Business.DTO;
using Curso.Business.Interfaces;
using Curso.Data.DB;
using Curso.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Business.Classes
{
    public class VeiculoBS: IVeiculoBusinessOperation
    {
        private readonly IVeiculoDataOperation _veiculoDataOperation;

        public VeiculoBS(IVeiculoDataOperation veiculoDataOperation) {
            _veiculoDataOperation = veiculoDataOperation;
        }

        public bool Delete(long id)
        {
            return _veiculoDataOperation.Delete(id);
        }

        public VeiculoDTO Get(long id)
        {
            var veiculoDB = _veiculoDataOperation.Get(id);
            
            return new VeiculoDTO
            {
                Id = veiculoDB.Id,
                Placa = veiculoDB.Placa,
                Marca = veiculoDB.Marca,
                Modelo= veiculoDB.Modelo,
                Cor= veiculoDB.Cor,
                Ano= veiculoDB.Ano,
                Tipo = new TipoVeiculoDTO { Id = veiculoDB.Tipo.Id, Descricao = veiculoDB.Tipo.Descricao}
            };
        }

        public VeiculoDTO Insert(VeiculoDTO veiculoDTO)
        {
            var veiculoDB = _veiculoDataOperation.Insert(new VeiculoDB
            {
                Id = veiculoDTO.Id,
                Placa = veiculoDTO.Placa,
                Marca = veiculoDTO.Marca,
                Modelo = veiculoDTO.Modelo,
                Cor = veiculoDTO.Cor,
                Ano = veiculoDTO.Ano,
                Tipo = new TipoVeiculoDB { Id = veiculoDTO.Tipo.Id,Descricao= veiculoDTO.Tipo.Descricao}
            });

            veiculoDTO.Id = veiculoDB.Id;
            return veiculoDTO;
        }

        public List<VeiculoDTO> List()
        {
            List<VeiculoDTO> listDto = new List<VeiculoDTO>();
            try
            {
                var listVeiculosDB = _veiculoDataOperation.List();
                foreach (var veiculoDB in listVeiculosDB)
                {
                    listDto.Add(new VeiculoDTO
                    {
                        Id = veiculoDB.Id,
                        Placa = veiculoDB.Placa,
                        Marca = veiculoDB.Marca,
                        Modelo = veiculoDB.Modelo,
                        Cor = veiculoDB.Cor,
                        Ano = veiculoDB.Ano,
                        Tipo = new TipoVeiculoDTO { Id = veiculoDB.Tipo.Id, Descricao = veiculoDB.Tipo.Descricao }

                    });
                }

            }
            catch (Exception)
            {

                throw;
            }

            return listDto;
        }

        public VeiculoDTO Update(VeiculoDTO veiculoDTO)
        {
            VeiculoDB veiculoDB = _veiculoDataOperation.Update(new VeiculoDB
            {
                Id = veiculoDTO.Id,
                Placa = veiculoDTO.Placa,
                Marca = veiculoDTO.Marca,
                Modelo = veiculoDTO.Modelo,
                Cor = veiculoDTO.Cor,
                Ano = veiculoDTO.Ano,
                Tipo = new TipoVeiculoDB { Id = veiculoDTO.Tipo.Id, Descricao = veiculoDTO.Tipo.Descricao }
            });

            return veiculoDTO;
        }


    }
}
