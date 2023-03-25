using AppelSoft.Mutitenancy.API.Context;
using AppelSoft.Mutitenancy.API.Repository.Entities;
using AppelSoft.Mutitenancy.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Internal;
using System.ComponentModel.Design;

namespace AppelSoft.Mutitenancy.API.Repository
{
    public class CompanyProductRepository : ICompanyProductRepository
    {
        private readonly MultitenancyContext _context;
        public CompanyProductRepository(MultitenancyContext context)
        {

            _context = context;
        }

        public CompanyProduct GetProduct(int id)
        {
            return _context.CompanyProduct.Where(x => x.Id == id).FirstOrDefault();
        }

       
    }
}
