using AutoMapper;
using Curso.Domain.DTO;
using Curso.Domain.Entities;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Curso.Service.Mappers
{
    public static class MapperDto
    {
        public static IMapper InitializeMapping()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TipoVeiculo, TipoVeiculoDTO>();
                cfg.CreateMap<TipoVeiculoDTO, TipoVeiculo>();

                cfg.CreateMap<Veiculo, VeiculoDTO>();
                cfg.CreateMap<VeiculoDTO, Veiculo>();


            });
            return mapperConfig.CreateMapper();
        }
    }
}
