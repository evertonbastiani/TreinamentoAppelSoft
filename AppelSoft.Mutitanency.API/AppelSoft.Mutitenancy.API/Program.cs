using AppelSoft.Mutitenancy.API.Authentication;
using AppelSoft.Mutitenancy.API.Context;
using AppelSoft.Mutitenancy.API.Repository;
using AppelSoft.Mutitenancy.API.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppelSoft.Mutitenancy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<MultitenancyContext>(options =>
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionMysql = config["ConnectionStrings:AppelSoftMutitenancy"].ToString();
                options.UseMySQL(builder.Configuration.GetConnectionString("AppelSoftMutitenancy"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region Repositories
           
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICompanyProductRepository, CompanyProductRepository>();

            #endregion

            #region Authentication

            var key = Encoding.ASCII.GetBytes(AuthenticationSecret.APISecret);
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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}