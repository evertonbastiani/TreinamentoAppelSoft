using Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repository.Context
{
    public  class CursoDBContext: DbContext
    {
        public CursoDBContext(DbContextOptions<CursoDBContext> options):base(options) { }

        public DbSet<TipoVeiculo> TipoVeiculo { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        

    }
}
