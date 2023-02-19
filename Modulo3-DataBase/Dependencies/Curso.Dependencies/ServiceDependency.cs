using Curso.Domain.Interfaces;
using Curso.Domain.Services;
using Curso.Repository.Interfaces;
using Curso.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.Dependencies
{
    public static class ServiceDependency
    {
        public static void  AddServiceDependency()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IVeiculoRepository, VeiculoRepository>();
            services.AddTransient<ITipoVeiculoRepository, TipoVeiculoRepository>();
            services.AddTransient<IServiceVeiculo, ServiceVeiculo>();
            services.AddTransient<IServiceTipoVeiculo, ServiceTipoVeiculo>();
        }
    }
}