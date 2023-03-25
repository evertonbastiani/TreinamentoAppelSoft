using AppelSoft.Mutitenancy.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppelSoft.Mutitenancy.API.Context
{
    public  class MultitenancyContext: DbContext
    {
        public MultitenancyContext(DbContextOptions<MultitenancyContext> options):base(options) { }

        public DbSet<User> Usuario { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CompanyProduct> CompanyProduct { get; set; }



    }
}
