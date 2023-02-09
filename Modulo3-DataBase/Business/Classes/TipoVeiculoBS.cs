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
    public class TipoVeiculoBS : ITipoVeiculoBusinessOperation
    {
        private readonly ITipoVeiculoDataOperaration _tipoVeiculoDataOperaration;

        public TipoVeiculoBS(ITipoVeiculoDataOperaration tipoVeiculoDataOperaration)
        {
            _tipoVeiculoDataOperaration = tipoVeiculoDataOperaration;
        }

        public bool Delete(long id)
        {
            return _tipoVeiculoDataOperaration.Delete(id);
        }

        public TipoVeiculoDTO Get(long id)
        {
            var tipoVeiculoDB = _tipoVeiculoDataOperaration.Get(id);
            return new TipoVeiculoDTO
            {
                Id = tipoVeiculoDB.Id,
                Descricao = tipoVeiculoDB.Descricao
            };
        }

        public TipoVeiculoDTO Insert(TipoVeiculoDTO tipoVeiculoDTO)
        {
            var tipoVeiculoDB = _tipoVeiculoDataOperaration.Insert(new TipoVeiculoDB
            {
                Id = tipoVeiculoDTO.Id,
                Descricao = tipoVeiculoDTO.Descricao
            });

            tipoVeiculoDTO.Id = tipoVeiculoDB.Id;
            return tipoVeiculoDTO;           
        }

        public List<TipoVeiculoDTO> List()
        {
            List<TipoVeiculoDTO> listDto = new List<TipoVeiculoDTO>();
            try
            {
                var listTiposDB = _tipoVeiculoDataOperaration.List();
                foreach (var tipoDB in listTiposDB)
                {
                    listDto.Add(new TipoVeiculoDTO
                    {
                        Id = tipoDB.Id,
                        Descricao = tipoDB.Descricao
                    });
                }

            }
            catch (Exception)
            {

                throw;
            }

            return listDto;
        }

        public TipoVeiculoDTO Update(TipoVeiculoDTO tipoVeiculoDTO)
        {
            TipoVeiculoDB tipoVeiculoDB = _tipoVeiculoDataOperaration.Update(new TipoVeiculoDB
            {
                Id = tipoVeiculoDTO.Id,
                Descricao = tipoVeiculoDTO.Descricao
            });

            return tipoVeiculoDTO;
        }
    }
}
