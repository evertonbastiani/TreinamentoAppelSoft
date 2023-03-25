using AppelSoft.Mutitenancy.API.Repository.Entities;

namespace AppelSoft.Mutitenancy.API.Repository.Interface
{
    public interface ICompanyRepository
    {
        Company GetCompany(int id);
    }
}
