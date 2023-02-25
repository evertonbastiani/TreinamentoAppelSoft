using AutoMapper;

namespace Curso.Service.Services
{
    public class ServiceBase
    {
        protected readonly IMapper mapper;
        public ServiceBase() { 
        
            mapper = Mappers.MapperDto.InitializeMapping();
        }
    }
}
