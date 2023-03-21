using AutoMapper;
using Curso.Domain.DTO;
using Curso.Domain.Entities;

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

                cfg.CreateMap<Usuario,UsuarioDTO>();
                cfg.CreateMap<UsuarioDTO, Usuario>();


            });
            return mapperConfig.CreateMapper();
        }
    }
}
