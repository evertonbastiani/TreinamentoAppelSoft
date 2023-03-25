using AppelSoft.Mutitenancy.API.Repository.Entities;

namespace AppelSoft.Mutitenancy.API.Repository.Interface
{
    public interface ICompanyProductRepository
    {
        CompanyProduct GetProduct(int id);
    }
}
