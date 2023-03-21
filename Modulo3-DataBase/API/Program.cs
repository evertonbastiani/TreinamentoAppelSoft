using Curso.Repository.Context;
using Curso.Repository.Interfaces;
using Curso.Repository.Repository;
using Curso.Service.Authentication;
using Curso.Service.Interfaces;
using Curso.Service.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Curso.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);  
            
            builder.Services.AddDbContext<CursoDBContext>(options =>
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionMysql = config["ConnectionStrings:CursoAppelSoft"].ToString();
                options.UseMySQL(builder.Configuration.GetConnectionString("CursoAppelSoft"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Repositories

            builder.Services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
            builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion

            #region Services

            builder.Services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();
            builder.Services.AddScoped<IVeiculoService, VeiculoService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            #endregion

            #region Authentication

            var key = Encoding.ASCII.GetBytes(AuthenticationSecret.CursoAPISecret);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

           

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}