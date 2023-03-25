using AppelSoft.Mutitenancy.API.Repository.Entities;

namespace AppelSoft.Mutitenancy.API.Repository.Interface
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IList<Product> GetProducts(int companyId);
    }
}
