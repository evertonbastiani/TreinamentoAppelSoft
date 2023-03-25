using AppelSoft.Mutitenancy.API.Context;
using AppelSoft.Mutitenancy.API.Repository.Entities;
using AppelSoft.Mutitenancy.API.Repository.Interface;

namespace AppelSoft.Mutitenancy.API.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly MultitenancyContext _context;
        public CompanyRepository(MultitenancyContext context)
        {

            _context = context;
        }

        public Company GetCompany(int id)
        {
            return _context.Company.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
