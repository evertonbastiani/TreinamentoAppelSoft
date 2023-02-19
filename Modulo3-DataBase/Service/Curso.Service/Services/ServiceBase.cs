using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
