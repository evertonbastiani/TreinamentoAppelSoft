using AppelSoft.Mutitenancy.API.Context;
using AppelSoft.Mutitenancy.API.Repository.Entities;
using AppelSoft.Mutitenancy.API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders.Internal;
using System.ComponentModel.Design;

namespace AppelSoft.Mutitenancy.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MultitenancyContext _context;
        public ProductRepository(MultitenancyContext context)
        {

            _context = context;
        }

        public Product GetProduct(int id)
        {
            return _context.Product.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<Product> GetProducts(int companyId)
        {
            IList<Product> listReturn = new List<Product>();
            var productsCompany = _context.CompanyProduct.Where(x => x.Id_Company == companyId).ToList();
            foreach (var item in productsCompany)
            {
                var product = _context.Product.Where(x => x.Id == item.Id_Product).FirstOrDefault();
                listReturn.Add(product);
            }

            return listReturn;

            //var listProducts = (from product in _context.Product
            //                    join pdc in _context.CompanyProduct on product.Id equals pdc.Id_Product                                
            //                    where pdc.Id_Company == companyId
            //                    select product).AsNoTracking().ToList();
            //return listProducts;
            
        }
    }
}
